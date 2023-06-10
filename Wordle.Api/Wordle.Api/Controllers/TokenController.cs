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
                new Claim("UserId", user.Id.ToString()),
                new Claim(Claims.UserName, user.UserName!.ToString()),
                new Claim(Claims.MasterOfTheUniverse, "MasterOfTheUniverse"),
            };

            if (user.BirthDate.HasValue)
            {
                claims.Add(new Claim(Claims.Age, Math.Floor((DateTime.UtcNow - user.BirthDate.Value).TotalDays / 365).ToString()));
                claims.Add(new Claim(Claims.Birthdate, user.BirthDate.Value.ToString("MM/dd/yyyy")));
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

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUser createUser)
    {
        if (string.IsNullOrEmpty(createUser.Username))
        {
            return BadRequest("Username is required");
        }
        if (string.IsNullOrEmpty(createUser.Password))
        {
            return BadRequest("Password is required");
        }
        if (string.IsNullOrEmpty(createUser.Name))
        {
            return BadRequest("Name is required");
        }
        var user = new AppUser
        {
            UserName = createUser.Username,
            Email = createUser.Username,
            Name = createUser.Name
        };
        var result = await _userManager.CreateAsync(user, createUser.Password);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }


    [HttpGet("TestEditWord")]
    [Authorize(Policy = Policies.EditWord)]
    public string TestEditWord()
    {
        return $"Authorized to edit words ${string.Join(", ", User.Claims.ToList())}";
    }

}