using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Wordle.Api.Identity;

public static class Policies
{
    public const String RandomAdmin = "RandomAdmin";
    public const String AgeReq = "AgeReq";
    public const String MoTUReq = "MoTUReq";

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


    public static void AgeReqPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim(Claims.Age);
        policy.RequireAssertion(context =>
        {
            var age = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Age);
            if (Double.TryParse(age?.Value, out double result))
            {
                return result > 20;
            }
            return false;
        });

    }

    public static void MoTUReqPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireClaim(Claims.MotU);
        policy.RequireAssertion(context =>
        {
            var MoTU = context.User.Claims.FirstOrDefault(c => c.Type == Claims.MotU);
            if (Double.TryParse(MoTU?.Value, out double result))
            {
                return (result.Equals("true"));
            }
            return false;
        });
    }

}
