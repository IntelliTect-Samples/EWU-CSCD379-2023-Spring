﻿using Microsoft.AspNetCore.Identity;
using Wordle.Api.Data;

namespace Wordle.Api.Identity;

public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await SeedRolesAsync(roleManager);

        await SeedAdminAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
    }

    private static async Task SeedAdminAsync(UserManager<AppUser> userManager)
    {
        if (await userManager.FindByEmailAsync("Admin@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Admin@intellitect.com",
                Email = "Admin@intellitect.com",
                Name = "Admin",
                MasterOfTheUniverse = true,
                Birthday = DateTime.MinValue.AddYears(1)
            };

            IdentityResult result = userManager.CreateAsync(user, "S3cur3P@ssw0rd!").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }
        if (await userManager.FindByEmailAsync("NormalUser@normal.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "NormalUser@normal.com",
                Email = "NormalUser@normal.com",
                Name = "NormalUser",
                MasterOfTheUniverse = false,
                Birthday = DateTime.Now.AddYears(-40)
            };

            IdentityResult result = userManager.CreateAsync(user, "Qwerty#3").Result;
            //I was going to use qwerty as the least secure password, but I wasn't allowed to

        }
    }
}