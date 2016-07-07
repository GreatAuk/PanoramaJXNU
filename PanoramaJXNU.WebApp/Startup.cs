using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PanoramaJXNU.WebApp.Startup))]
namespace PanoramaJXNU.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
