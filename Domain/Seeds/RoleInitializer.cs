using DAL.Constant;
using Microsoft.AspNetCore.Identity;

namespace Domain.Seeds
{
    public class RoleInitializer
    {
        public static async Task InitializeRole(RoleManager<IdentityRole> roleManager)
        {
            foreach (var roleName in typeof(Roles).GetFields())
            {
                if (!await roleManager.RoleExistsAsync(roleName.Name))
                {
                    var role = new IdentityRole { Name = roleName.Name };
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}