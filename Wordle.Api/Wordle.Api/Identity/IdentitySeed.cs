using Microsoft.AspNetCore.Identity;
using Wordle.Api.Data;

namespace Wordle.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);

        await SeedTestUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
        if (!await roleManager.RoleExistsAsync(Roles.Special))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Special));
        }
        if (!await roleManager.RoleExistsAsync(Roles.MasterOfTheUniverse))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.MasterOfTheUniverse));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User
        if (await userManager.FindByEmailAsync("Admin@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Admin@intellitect.com",
                Email = "Admin@intellitect.com",
                Name = "Admin",
                BDay = new DateTime(1772, 10, 22),
                MasterOfTheUniverse = "MOTU"
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
                await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);
            }
        }
    }
    private static async Task SeedTestUserAsync(UserManager<AppUser> userManager)
    {
        if (await userManager.FindByEmailAsync("over21@test") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "over21@test",
                Email = "over21@test",
                Name = "over21",
                BDay = new DateTime(1990, 10, 22),
                MasterOfTheUniverse = "MOTU"
            };

            IdentityResult result = userManager.CreateAsync(user, "Tester.123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);

            }
        }

        if (await userManager.FindByEmailAsync("under21@test") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "under21@test",
                Email = "under21@test",
                Name = "under21",
                BDay = new DateTime(2015, 10, 22),
                MasterOfTheUniverse = "MOTU"
            };

            IdentityResult result = userManager.CreateAsync(user, "Tester.321").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);

            }
        }
    }
}
