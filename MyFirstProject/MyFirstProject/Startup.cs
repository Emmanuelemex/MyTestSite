using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstProject.Startup))]
namespace MyFirstProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
