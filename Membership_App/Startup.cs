using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Membership_App.Startup))]
namespace Membership_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
