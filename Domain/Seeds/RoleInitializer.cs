using DAL.Enum;
using Microsoft.AspNetCore.Identity;

namespace Domain.Seeds
{
    public class RoleInitializer
    {

        public static async Task InitializeRole(RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetNames(typeof(Role));

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    await roleManager.CreateAsync(role);
                }
            }

        }
    }
}
