using ClickRaceService.DataObjects;
using ClickRaceService.Gestora;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(ClickRaceService.Startup))]

namespace ClickRaceService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			app.MapSignalR();
			GameInfo.players = new Dictionary<string, clsPlayer>();
			GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(6);
		}
    }
}