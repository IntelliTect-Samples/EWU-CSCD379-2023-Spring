using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity
{
    public static class Policies
    {
        public const string CanCreateDeleteWords = "CanCreateDeleteWords";

        public static void CanCreateDeleteWordsPolicy(AuthorizationPolicyBuilder builder)
        {
            builder.RequireRole(Roles.MasterOfTheUniverse);
            builder.RequireAssertion(context =>
            {
                DateTime date = DateTime.UtcNow;
                var birthday = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Birthday);
                bool validDate = DateTime.TryParse(birthday?.Value, out DateTime result);
                int age = (new DateTime(1, 1, 1) + (date - result)).Year - 1;
                return validDate && age >= 21;
            });
        }
    }
}
