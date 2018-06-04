using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Integrador.Startup))]
namespace Integrador
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
