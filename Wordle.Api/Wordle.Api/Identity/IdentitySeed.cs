using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Wordle.Api.Data;

namespace Wordle.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager, roleManager);

        await UpdateBirthdates(db);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
        var role = roleManager.Roles.First(f => f.Name == Roles.Admin);
        if (!(await roleManager.GetClaimsAsync(role)).Any())
        {
            await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(Claims.MotU, "true"));
        }
        if (!await roleManager.RoleExistsAsync(Roles.Special))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Special));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Seed Admin User
        if (await userManager.FindByEmailAsync("Admin@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
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

        if (await userManager.FindByEmailAsync("meg@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "meg@intellitect.com",
                Email = "meg@intellitect.com",
                Name = "Meg",
                BirthDate = (new DateTime(1990, 1, 1))
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                //await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
                var role = roleManager.Roles.First(f => f.Name == Roles.Special);
                await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(Claims.MotU, "true"));
            }
        }

        if (await userManager.FindByEmailAsync("matt@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "matt@intellitect.com",
                Email = "matt@intellitect.com",
                Name = "Matt",
                BirthDate= (new DateTime(1980, 1, 1))
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                //await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
                var role = roleManager.Roles.First(f => f.Name == Roles.Special);
                await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(Claims.MotU, "false"));
            }
        }

        if (await userManager.FindByEmailAsync("FrostyTheSnowman@intellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "FrostyTheSnowman@intellitect.com",
                Email = "FrostyTheSnowman@intellitect.com",
                Name = "FrostyTheSnowman",
                BirthDate = (new DateTime(2022, 1, 1))
            };

            IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

            if (result.Succeeded)
            {
                //await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
                var role = roleManager.Roles.First(f => f.Name == Roles.Special);
                await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(Claims.MotU, "true"));
            }
        }

    }

    private static async Task UpdateBirthdates(AppDbContext db)
    {
        foreach (var user in db.Users.Where(f => !f.BirthDate.HasValue))
        {
            user.BirthDate = (new DateTime(1980, 1, 1)).AddDays((new Random()).Next(5000) - 1000);
        }
        await db.SaveChangesAsync();
    }
}