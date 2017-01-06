using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projekt.NETWeb.Startup))]
namespace Projekt.NETWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
