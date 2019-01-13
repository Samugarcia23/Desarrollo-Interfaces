using _21_GameTest_Test.Models.Entidades;
using _21_GameTest_Test.ViewModel;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _21_GameTest_Test
{
	/// <summary>
	/// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>

	public sealed partial class MainPage : Page
    {
		private int estado = 0;
		public MiViewModel gameVM { get; set; } = new MiViewModel();
		public HubConnection conn { get; set; }
		public IHubProxy proxy { get; set; }
		public MainPage()
        {
            this.InitializeComponent();
			this.DataContext = gameVM;
			SignalR();
		}

		private void BtnSend_Click(object sender, RoutedEventArgs e)
		{
			if (tbUser.Text == "")
				showDialog();
			else
			{
				btnSend.IsEnabled = false;
				gameVM.player.Username = tbUser.Text;
				proxy.Invoke("join", tbUser.Text);
			}
		}

		private async void showDialog()
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				ContentDialog dialog;
				ContentDialogResult alse;
				dialog = new ContentDialog
				{
					Title = "Error",
					Content = "Introduce un nombre!",
					CloseButtonText = "Ok"
				};
				dialog.ShowAsync();
			}
			);
		}

		private void MainRp_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			if (estado == 3)
			{
				gameVM.points++;
				proxy.Invoke("click");
			}		
		}

		private async void gameEnd(List<clsPlayer> listadoJugadores)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				showWinnerDialog(listadoJugadores);
				estado = 0;
				reiniciarPartida();
			}
			);
		}

		private async void showWinnerDialog(List<clsPlayer> jugadores)
		{
			ContentDialog dialog;

			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				string stringGanadores = "";

				for(int i = 0; i < jugadores.Count; i++)
				{
					stringGanadores += $"{i+1}º {jugadores[i].Username}: {jugadores[i].points} puntos {Environment.NewLine}";
				}
					
				dialog = new ContentDialog
				{
					Title = "Fin de partida",
					Content = stringGanadores,
					
					CloseButtonText = "Nueva Partida"
				};
			
				dialog.ShowAsync();
			}
			);
		}

		private void reiniciarPartida()
		{
			tbUser.Text = "";
			tbUser.IsEnabled = true;
			btnSend.IsEnabled = true;
			img1.Source = new BitmapImage(new Uri("ms-appx:///Assets/red.png"));
			img2.Source = new BitmapImage(new Uri("ms-appx:///Assets/red.png"));
			img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/red.png"));
			gameVM.points = 0;
			tbUser.Focus(FocusState.Programmatic);
		}

		public void SignalR()
		{
			conn = new HubConnection("http://clickrace.azurewebsites.net/");
			//conn = new HubConnection("http://localhost:58202");
			proxy = conn.CreateHubProxy("gameHub");
			conn.Start();
			proxy.On<int>("actualizarPlayers", actualizarPlayers);
			proxy.On<int>("gestionPartida", gestionPartida);
			proxy.On<List<clsPlayer>>("gameEnd", gameEnd);
			proxy.On<int>("actualizarTiempo", actualizarTiempo);
			proxy.On<int>("actualizarPuntos", actualizarPuntos);
		}

		public async void actualizarPlayers(int players)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				gameVM.jugadoresConectados = players;
				if (players >= 4)
					btnSend.IsEnabled = false;
				else
					btnSend.IsEnabled = true;
			}
			);
		}

		public async void actualizarTiempo(int tiempo)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				gameVM.counter = tiempo;
			}
			);
		}

		public async void actualizarPuntos(int puntos)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				gameVM.player.points = puntos;
			}
			);
		}

		public async void gestionPartida(int estado)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				this.estado = estado;
				if (estado == 0)
					img1.Source = new BitmapImage(new Uri("ms-appx:///Assets/yellow.png"));
				if (estado == 1)
					img2.Source = new BitmapImage(new Uri("ms-appx:///Assets/yellow.png"));
				if (estado == 2)
					img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/yellow.png"));
				if (estado == 3)
				{
					img1.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
					img2.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
					img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
					img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
				}
			}
			);	
		}
	}
}
