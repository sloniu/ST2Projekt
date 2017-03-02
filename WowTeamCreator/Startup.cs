using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WowTeamCreator.Startup))]
namespace WowTeamCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
