using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projekt.NETStrona.Startup))]
namespace Projekt.NETStrona
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
