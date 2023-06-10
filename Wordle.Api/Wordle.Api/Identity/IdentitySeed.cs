using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Wordle.Api.Data;

namespace Wordle.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager)
    {
        await SeedWordEditorAsync(userManager);
    }

    private static async Task SeedWordEditorAsync(UserManager<AppUser> userManager)
    {
        // Seed user that can edit words
        if (await userManager.FindByNameAsync("Can Edit Word") == null)
        {
            AppUser user = new()
            {
                UserName = "MasterUser",
                Name = "Can Edit Word",
                BirthDate = new DateTime(1995, 6, 12)
            };

            IdentityResult result = userManager.CreateAsync(user, "Password321!").Result;

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

        // Seed user that cannot edit words
        if (await userManager.FindByNameAsync("Cannot Edit Word") == null)
        {
            AppUser user = new()
            {
                UserName = "joe",
                Name = "Cannot Edit Word",
                BirthDate = new DateTime(2015, 6, 10)
            };

            IdentityResult result = userManager.CreateAsync(user, "Password321!").Result;

            if (result.Succeeded)
            {
                var ClaimsList = new List<Claim>()
                {
                    new Claim(Claims.Birthdate, user.BirthDate.Value.ToString("MM/dd/yyyy")),
                };
                await userManager.AddClaimsAsync(user, ClaimsList);
            }
        }
    }
}