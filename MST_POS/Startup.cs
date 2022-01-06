using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MST_POS.Startup))]
namespace MST_POS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
