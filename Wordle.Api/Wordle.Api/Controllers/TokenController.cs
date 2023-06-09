using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wordle.Api.Data;
using Wordle.Api.Identity;
using Wordle.Api.Models;

namespace Wordle.Api.Controllers;
[Route("Token")]
[ApiController]
public class TokenController:Controller
{
    public AppDbContext _context;
    public UserManager<AppUser> _userManager;
    public JwtConfiguration _jwtConfig;
    public TokenController(AppDbContext context, UserManager<AppUser> userManager, JwtConfiguration jwtConfig)
    {
        _context = context;
        _userManager = userManager;
        _jwtConfig = jwtConfig;
    }
    [HttpPost("GetToken")]
    public async Task<IActionResult> GetToken([FromBody] UserCredentials userCredentials)
    {
        if (string.IsNullOrEmpty(userCredentials.UserName)) 
        {
            return BadRequest("Bad username");
        }
        if (string.IsNullOrEmpty(userCredentials.Password)) 
        {
            return BadRequest("Bad Password");
        }

        var user = _context.Users.FirstOrDefault(u  => u.UserName == userCredentials.UserName);

        if (user == null) { return Unauthorized("Invalid account."); }

        bool results = await _userManager.CheckPasswordAsync(user, userCredentials.Password);
        if (results)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(Claims.UserId, user.Id.ToString()),
                new Claim(Claims.Random, (new Random()).NextDouble().ToString()),
                new Claim(Claims.UserName, user.UserName!.ToString().Substring(0, user.UserName.ToString().IndexOf("@"))),
                new Claim(Claims.MotU, "true"),
            };
            if (user.BirthDate.HasValue)
            {
                claims.Add(new Claim(Claims.Age, Math.Floor((DateTime.UtcNow - user.BirthDate.Value).TotalDays / 365).ToString()));
                claims.Add(new Claim(Claims.Birthdate, user.BirthDate.Value.ToString("MM/dd/yyyy")));
            }
            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtConfig.ExpirationInMinutes),
                signingCredentials: credentials
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {token = jwtToken});
        }
        return Unauthorized("Bad login.");
    }

}
