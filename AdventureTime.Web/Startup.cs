using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdventureTime.Web.Startup))]
namespace AdventureTime.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
