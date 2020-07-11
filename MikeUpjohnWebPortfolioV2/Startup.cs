using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MikeUpjohnWebPortfolioV2.Startup))]
namespace MikeUpjohnWebPortfolioV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
