using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TutorGuide.Startup))]
namespace TutorGuide
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
