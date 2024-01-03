using BookShoppingCartMvcUI.Constants;
using Microsoft.AspNetCore.Identity;

namespace BookShoppingCartMvcUI.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();

            // Add some roles to DB
            //var roleAdmin = await roleMgr.GetRoleNameAsync(new IdentityRole(Roles.Admin.ToString()));
            //if(string.IsNullOrWhiteSpace(roleAdmin))
            {
                await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            }

            //var roleUser = await roleMgr.GetRoleNameAsync(new IdentityRole(Roles.User.ToString()));
            //if (string.IsNullOrWhiteSpace(roleUser))
            {
                await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));
            }

            // Add admin user to DB

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var user = await userMgr.FindByEmailAsync(admin.Email);
            if (user == null)
            {
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
    }
}
