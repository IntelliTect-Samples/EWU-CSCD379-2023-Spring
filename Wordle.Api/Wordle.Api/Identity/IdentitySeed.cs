using Microsoft.AspNetCore.Identity;
using Wordle.Api.Data;

namespace Wordle.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        await SeedRandomUserAsynnc(userManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);

        await SeedBirthdate(db);
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
    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User
        if (await userManager.FindByEmailAsync("Admin@wordle.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Admin@wordle.com",
                Email = "Admin@wordle.com",
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

    public static async Task SeedRandomUserAsynnc(UserManager<AppUser> userManager)
    {
        if (await userManager.FindByEmailAsync("Random@wordle.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "Random@wordle.com",
                Email = "Random@wordle.com",
                Name = "Bob"
            };

            IdentityResult result = userManager.CreateAsync(user, "Password").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Special);
            }
        }
    }

    public static async Task SeedBirthdate(AppDbContext db)
    {
        foreach (var user in db.Users.Where(f => !f.BirthDate.HasValue)) {
            if (user.Name.StartsWith("Admin"))
            {
               user.BirthDate = new DateTime(1990, 10, 10);
            } else if (user.Name.StartsWith("Random"))
            {
                user.BirthDate = new DateTime(2015, 5, 10);
            } else { user.BirthDate = new DateTime(1980, 10, 10); }
        }
        await db.SaveChangesAsync();
    }
}