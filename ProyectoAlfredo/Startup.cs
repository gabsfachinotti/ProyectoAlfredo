using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoAlfredo.Startup))]
namespace ProyectoAlfredo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
