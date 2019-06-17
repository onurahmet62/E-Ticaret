using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcGroupApp.Startup))]
namespace MvcGroupApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
