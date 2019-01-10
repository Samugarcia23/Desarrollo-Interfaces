using Microsoft.AspNet.SignalR;
using SamChatNervionService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamChatNervionService.Hubs
{
	public class ChatHub : Hub
	{
		public void Send(ChatMessge message)
		{
			Clients.All.broadcastMessage(message);
		}
	}
}