using DAL.Constant;
using Microsoft.AspNetCore.Identity;

namespace Domain.Seeds
{
    public class RoleInitializer
    {
        public static async Task InitializeRole(RoleManager<IdentityRole> roleManager)
        {
            foreach (var roleName in new[]
            {
                Roles.SUPER_ADMIN,
                Roles.DIRECTOR,
                Roles.ACCOUNTANT,
                Roles.MANAGER,
                Roles.SENIOR_SURVEYOR,
                Roles.MIDDLE_SURVEYOR,
                Roles.JUNIOR_SURVEYOR
            })
            {
                if (await roleManager.FindByNameAsync(roleName) == null)
                {
                    var role = new IdentityRole { Name = roleName };
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}