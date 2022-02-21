using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RacingHub.Startup))]
namespace RacingHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
