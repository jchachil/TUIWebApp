using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TUIFront.Startup))]
namespace TUIFront
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
