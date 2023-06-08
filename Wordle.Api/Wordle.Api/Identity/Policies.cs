using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity;

public static class Policies
{
    public const string MasterOfTheUniverse = "MasterOfTheUniverse";
    public static void MasterOfTheUniversePolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireAssertion(context =>
        {
            var master = context.User.Claims.FirstOrDefault(c => c.Type == Claims.MasterOfTheUniverse);
            var birthday = context.User.Claims.FirstOrDefault(c => c.Type == Claims.DateOfBirth);
            if (master != null && birthday != null && Boolean.Parse(master.Value))
            {
                var birthdayDate = DateTime.Parse(birthday.Value).Date;
                var age = DateTime.Today.Subtract(birthdayDate);
                if (age.TotalDays >= 7670)//21 year in days
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        });
    }
}