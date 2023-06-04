﻿using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string RandomAdmin = "RandomAdmin";
    public const string NewPolicyName = "NewPolicy"; //change names


    public static void RandomAdminPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireRole(Roles.Admin);
        policy.RequireAssertion(context =>
        {
            var random = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Random);
            if (Double.TryParse(random?.Value, out double result))
            {
                return result > 0.5;
            }
            return false;
        });
    }

    public static void NewPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim(Claims.MasterOfTheUniverse); 
        policy.RequireAssertion(context => 
        {
            DateTime currentDate = DateTime.Now;
            DateTime DOB = DateTime.Parse(context.User.Claims.FirstOrDefault(c => c.Type == Claims.Dob)!.Value);
            int age = currentDate.Year - DOB.Year;

            // Check if the user has already had their birthday this year
            if (DOB.Date > currentDate.AddYears(-age))
                age--;

            return age > 21;
        });
    }
}