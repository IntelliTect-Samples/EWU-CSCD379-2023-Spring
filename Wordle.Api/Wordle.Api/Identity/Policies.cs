using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string RandomAdmin = "RandomAdmin";

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
    public const string MasterAndAge = "MasterAndAgePolicy";

    public static void MasterAndAgePolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim(Claims.MasterOfTheUniverse);
        policy.RequireAssertion(context =>
        {
            var userDateOfBirth = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Age);
            DateTime now = DateTime.Today;
            if (userDateOfBirth != null && DateTime.TryParse(userDateOfBirth.Value, out DateTime res))
            {
                int age = now.Year - res.Year;
                if (res.Date > now.AddYears(-age))
                {
                    age = age -1;
                }
                if (age >= 21)
                {
                    return true;
                }
            }
            return false;
        });
    }
}