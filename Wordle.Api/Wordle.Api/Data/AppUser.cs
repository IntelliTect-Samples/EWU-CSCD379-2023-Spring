using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace Wordle.Api.Data;

public class AppUser: IdentityUser
{
    public int UserId { get; set; }
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool MasterOfTheUniverse { get; set; }

}