using ClickRaceService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClickRaceService.Gestora
{
	public static class GameInfo
	{
		public static IDictionary<string, clsPlayer> players { get; set; }
		public static int maxPlayers = 1;
	}
}