using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string MasterOfTheUniverse = "MasterOfTheUniverse";

    public static void IsMasterOfTheUniverse(AuthorizationPolicyBuilder policy)
    {
        policy.RequireAssertion(context =>
        {
            return context.User.Claims.Any(c => c.Type == Claims.MasterOfTheUniverse);
        });
    }
}