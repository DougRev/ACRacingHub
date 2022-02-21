using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RacingHubMVC.Startup))]
namespace RacingHubMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
