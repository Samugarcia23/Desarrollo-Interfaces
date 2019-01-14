using ClickRaceService.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using ClickRaceService.Gestora;

namespace ClickRaceService.Hubs
{
	public class gameHub : Hub
	{
		public void click()
		{
			GameInfo.players[Context.ConnectionId].points++;
			Clients.Caller.actualizarPuntos(GameInfo.players[Context.ConnectionId].points);
		}

		public override Task OnConnected()
		{
			Clients.Caller.actualizarPlayers(GameInfo.players.Count);
			Clients.Caller.actualizarMaxPlayers(GameInfo.maxPlayers);

			return base.OnConnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			GameInfo.players.Remove(Context.ConnectionId);
			Clients.Others.actualizarPlayers(GameInfo.players.Count);

			return base.OnDisconnected(stopCalled);
		}

		public void join(string name)
		{
			if (GameInfo.players.Count < GameInfo.maxPlayers)
			{
				GameInfo.players.Add(Context.ConnectionId, new clsPlayer(name));
				Clients.Caller.actualizarPuntos(0);
				Clients.All.actualizarPlayers(GameInfo.players.Count);

				if (GameInfo.players.Count == GameInfo.maxPlayers)
				{
					gestionPartida();
				}				
			}
		}

		private void reiniciarPartida()
		{
			GameInfo.players = new Dictionary<string, clsPlayer>();
			Clients.All.actualizarPuntos(0);
			Clients.All.actualizarTiempo(30);
			Clients.All.actualizarPlayers(0);
		}

		private void gestionPartida()
		{
			Clients.All.gestionPartida(0);
			System.Threading.Thread.Sleep(1000);
			Clients.All.gestionPartida(1);
			System.Threading.Thread.Sleep(1000);
			Clients.All.gestionPartida(2);
			System.Threading.Thread.Sleep(1000);
			Clients.All.gestionPartida(3);

			Clients.All.actualizarTiempo(30);

			for (int i = 30; i>=0; i--)
			{
				System.Threading.Thread.Sleep(1000);
				Clients.All.actualizarTiempo(i);
			}

			List<clsPlayer> listadoJugadores = new List<clsPlayer>(GameInfo.players.Values.OrderByDescending(x => x.points));
			Clients.All.gameEnd(listadoJugadores);
			reiniciarPartida();
		}
	}
}