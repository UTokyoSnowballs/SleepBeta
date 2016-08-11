using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SleepExplorer.Startup))]
namespace SleepExplorer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
