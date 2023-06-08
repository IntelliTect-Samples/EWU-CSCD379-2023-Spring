using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string EditWord = "EditWord";

    public static void EditWordPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim(Claims.MasterOfTheUniverse);
        policy.RequireAssertion(context =>
        {
            var ageString = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Age);
            if (ageString != null)
            {
                int age;
                if (int.TryParse(ageString.Value, out age))
                {
                    return age >= 21;
                }
            }
            return false;
        });
    }
}