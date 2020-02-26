using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoadsheddingSystem.Startup))]
namespace LoadsheddingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
