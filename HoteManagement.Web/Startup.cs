using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HoteManagement.Web.Startup))]
namespace HoteManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
