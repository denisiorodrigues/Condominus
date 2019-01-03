using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DR.Condominus.UI.Site.Startup))]
namespace DR.Condominus.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
