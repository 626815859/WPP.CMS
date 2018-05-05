using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WP.CMS.WebApp.Startup))]
namespace WP.CMS.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
