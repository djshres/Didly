using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Didly.Startup))]
namespace Didly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
