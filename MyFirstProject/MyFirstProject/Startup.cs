using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MyFirstProject.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstProject.Startup))]
namespace MyFirstProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("SuperAdmin"))
            {
                //create super admin role
                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);


                //create default user
                var user = new ApplicationUser();
                user.UserName = "sa@domain.com";
                user.Email = "sa@domain.com";
                string pwd = "Password@2017";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }

            }
        }
    }
}
