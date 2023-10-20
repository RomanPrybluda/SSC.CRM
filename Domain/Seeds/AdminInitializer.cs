using DAL.Constant;
using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Domain.Seeds
{
    public class AdminInitializer
    {

        public static async Task InitializeRole(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            string adminEmail = "admin@ssc.com";
            string adminPassword = "AdminSsc!123#";
            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "ADMIN",
                    LastName = "ADMIN",
                };

                var result = await userManager.CreateAsync(admin, adminPassword);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors?.FirstOrDefault()?.Description);
                }

                result = await userManager.AddToRoleAsync(admin, Roles.SUPER_ADMIN);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors?.FirstOrDefault()?.Description);
                }

            }

        }
    }
}