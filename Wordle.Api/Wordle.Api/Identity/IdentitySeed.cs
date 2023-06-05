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

        // Seed Masters Of The Universe
        await SeedMasterOfUniverseAsync(userManager);
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
            AppUser user = new AppUser {
                UserName = "Admin@intellitect.com",
                Email = "Admin@intellitect.com",
                Name = "Admin",
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
            }
        }
    }

    private static async Task SeedMasterOfUniverseAsync(UserManager<AppUser> userManager)
    {
        // Seed Nolan MasterOfTheUniverse
        if (await userManager.FindByEmailAsync("nposey@intellitect.com") == null)
        {
            AppUser user = new AppUser {
                UserName = "nposey@intellitect.com",
                Email = "nposey@intellitect.com",
                Name = "Nolan",
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
                await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);
            }
        }

        // Seed Hunter MasterOfTheUniverse
        if (await userManager.FindByEmailAsync("hthompson@intellitect.com") == null)
        {
            AppUser user = new AppUser {
                UserName = "hthompson@intellitect.com",
                Email = "hthompson@intellitect.com",
                Name = "Hunter",
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
}
