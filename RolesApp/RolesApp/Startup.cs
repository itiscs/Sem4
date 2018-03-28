using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RolesApp.Startup))]
namespace RolesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
