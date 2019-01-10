using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SamChatNervionService.Startup))]

namespace SamChatNervionService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
			app.MapSignalR();
		}
    }
}