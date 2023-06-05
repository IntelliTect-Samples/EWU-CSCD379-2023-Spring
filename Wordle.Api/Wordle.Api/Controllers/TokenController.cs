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
public class TokenController : Controller
{
    public AppDbContext _context;
    public UserManager<AppUser> _userManager;
    public JwtConfiguration _jwtConfiguration;
    public TokenController(AppDbContext context, UserManager<AppUser> userManager, JwtConfiguration jwtConfiguration)
    {
        _context = context;
        _userManager = userManager;
        _jwtConfiguration = jwtConfiguration;
    }

    [HttpPost("GetToken")]
    public async Task<IActionResult> GetToken([FromBody] UserCredentials userCredentials)
    {
        if (string.IsNullOrEmpty(userCredentials.Username))
        {
            return BadRequest("Username is required");
        }
        if (string.IsNullOrEmpty(userCredentials.Password))
        {
            return BadRequest("Password is required");
        }

        var user = _context.Users.FirstOrDefault(u => u.UserName == userCredentials.Username);

        if (user is null) { return Unauthorized("The user account was not found"); }

        bool results = await _userManager.CheckPasswordAsync(user, userCredentials.Password);
        if (results)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(Claims.Birthday, user.Birthday.ToString())
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtConfiguration.ExpirationInMinutes),
                signingCredentials: credentials
            );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = jwtToken });
        }
        return Unauthorized("The username or password is incorrect");
    }

    [HttpPost("TestMasterUniverse")]
    [Authorize(Policy=Policies.CanCreateDeleteWords)]
    public string TestMasterUniverse()
    {
        return User.IsInRole("MasterOfTheUniverse").ToString();
    }
}