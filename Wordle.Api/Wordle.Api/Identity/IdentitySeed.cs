using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Wordle.Api.Data;

namespace Wordle.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await SeedRolesAsync(roleManager);
        await SeedWordEditorAsync(userManager);
    }

    // TO DO: remove admin b/c not using
    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
    }

    private static async Task SeedWordEditorAsync(UserManager<AppUser> userManager)
    {
        // Seed user that can edit words
        if (await userManager.FindByNameAsync("Vera Testing") == null)
        {
            AppUser user = new()
            {
                UserName = "CoolBeans",
                Name = "Vera Testing",
                BirthDate = new DateTime(2001, 10, 29)
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd").Result;

            if (result.Succeeded)
            {
                var ClaimsList = new List<Claim>()
                {
                    new Claim(Claims.Birthdate, user.BirthDate.Value.ToString("MM/dd/yyyy")),
                    new Claim(Claims.MasterOfTheUniverse, true.ToString())
                };
                await userManager.AddClaimsAsync(user, ClaimsList);
            }
        }
    }
}