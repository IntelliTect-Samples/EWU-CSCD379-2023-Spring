using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using Wordle.Api.Data;
using Wordle.Api.Models;

namespace Wordle.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(AppDbContext db, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);

        //seed users
        await SeedUser1Async(userManager, db);
        await SeedUser2Async(userManager, db);
        await SeedUser3Async(userManager, db);


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
        if (await userManager.FindByEmailAsync("AdminIntellitect.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "AdminIntellitect.com",
                Email = "AdminIntellitect.com",
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








    // The Method that seeds the users 
    private static async Task SeedUser1Async(UserManager<AppUser> userManager, AppDbContext db)
    {

        // Matt enters the stage
        if (await userManager.FindByEmailAsync("matt.com") == null)
        {
            AppUser user = new AppUser
            {
                UserName = "matt.com",
                Email = "matt.com",
                Name = "matt",
                DateOfBirth = new DateTime(2020, 3, 3)
            };

            IdentityResult result = await userManager.CreateAsync(user, "P@ssw0rd123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
                

            }
        }

    }

    private static async Task SeedUser2Async(UserManager<AppUser> userManager, AppDbContext db)
    {
        if (await userManager.FindByEmailAsync("meg.com") == null)
        {
            AppUser user1 = new AppUser
            {
                UserName = "meg.com",
                Email = "meg.com",
                Name = "Meg Woodford",
                DateOfBirth = new DateTime(2020, 3, 3)
            };

            IdentityResult result1 = await userManager.CreateAsync(user1, "P@ssw0rd1234");

            if (result1.Succeeded)
            {
                await userManager.AddToRoleAsync(user1, Roles.Admin);
                await userManager.AddToRoleAsync(user1, Roles.Special);
                await userManager.AddClaimAsync(user1, new Claim(Claims.MasterOfTheUniverse, user1.MasterOfTheUniverse.ToString()));

            }
        }
    }
    private static async Task SeedUser3Async(UserManager<AppUser> userManager, AppDbContext db)
    {
        if (await userManager.FindByEmailAsync("FrostyTheSnowman.com") == null)
        {
            AppUser user1 = new AppUser
            {
                UserName = "FrostyTheSnowman.com",
                Email = "FrostyTheSnowman.com",
                Name = "Frosty The Snowman",
                DateOfBirth = new DateTime(1874, 10, 21)
            };

            IdentityResult result1 = await userManager.CreateAsync(user1, "P@ssw0rd12345");

            if (result1.Succeeded)
            {
                await userManager.AddToRoleAsync(user1, Roles.Admin);
                await userManager.AddToRoleAsync(user1, Roles.Special);
                await userManager.AddClaimAsync(user1, new Claim(Claims.MasterOfTheUniverse, user1.MasterOfTheUniverse.ToString()));

            }
        }
    }


    /*
    
        
    */



}
