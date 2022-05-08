using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComptabilitePFE.Startup))]
namespace ComptabilitePFE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
