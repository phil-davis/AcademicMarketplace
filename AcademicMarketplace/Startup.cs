using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademicMarketplace.Startup))]
namespace AcademicMarketplace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
