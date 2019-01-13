using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickRaceService.DataObjects
{
	public class clsPlayer
	{
		public int points { get; set; }
		public string Username { get; set; }

		public clsPlayer(string username)
		{
			this.Username = username;
			points = 0;
		}
	}
}
