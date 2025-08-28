using Microsoft.AspNetCore.Identity;

namespace HealthBookTracker.Services
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string adminUsername = "vasili";
            string adminPassword = "пароль123";

            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                var user = new IdentityUser { UserName = adminUsername };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
