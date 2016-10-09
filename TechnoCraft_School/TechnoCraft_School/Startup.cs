using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechnoCraft_School.Startup))]
namespace TechnoCraft_School
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}


