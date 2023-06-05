using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Identity
{
    public static class IdentitySeed
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
            await SeedUsersAsync(userManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync(Roles.MasterOfTheUniverse))
                await roleManager.CreateAsync(new IdentityRole(Roles.MasterOfTheUniverse));
        }

        private static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(await userManager.Users.AnyAsync())
            {
                AppUser plainUser = new()
                {
                    UserName = "Joe123",
                    Email = "Joe123@gmail.com",
                    Name = "Joe",
                    Birthday = new DateTime(2004, 5, 26)
                };

                AppUser masterUser = new()
                {
                    UserName = "He-Man",
                    Email = "universemaster@mattel.com",
                    Name = "He-Man",
                    Birthday = new DateTime(1987, 8, 7)
                };

                IdentityResult plainResult = userManager.CreateAsync(plainUser, "s3curEp@ssw0rd123").Result;
                IdentityResult masterResult = userManager.CreateAsync(masterUser, "an0thErP@s$word123").Result;

                if(plainResult.Succeeded && masterResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(masterUser, Roles.MasterOfTheUniverse);
                }
            }
        }
    }
}
