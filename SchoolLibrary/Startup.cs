using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolLibrary.Startup))]
namespace SchoolLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
