using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InscripcionNatacion.Startup))]
namespace InscripcionNatacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
