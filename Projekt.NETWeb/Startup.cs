using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Projekt.NETWeb.Models;

[assembly: OwinStartupAttribute(typeof(Projekt.NETWeb.Startup))]
namespace Projekt.NETWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        //Create Admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //Create Admin Role and create a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                //Create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Create a Admin super user
                var user = new ApplicationUser();
                user.UserName = "AdminName";
                string userPassword = "AdminPassword";
                var adminUser = UserManager.Create(user, userPassword);

                //Add default User to Role Admin   
                if (adminUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
