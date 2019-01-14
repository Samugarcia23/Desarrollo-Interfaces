using _21_GameTest_Test.Models.Entidades;
using _21_GameTest_Test.ViewModel;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
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
		MediaElement element = new MediaElement();
		MediaPlayer player = new MediaPlayer();

		public MiViewModel gameVM { get; set; } = new MiViewModel();
		public HubConnection conn { get; set; }
		public IHubProxy proxy { get; set; }
		public MainPage()
        {
            this.InitializeComponent();
			this.DataContext = gameVM;
			SignalR();
		}

		/// <summary>
		/// Metodo que invoca al metodo 'join' del server y desabilita el boton Jugar y el tbUser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Metodo que muestra un dialog de error en caso de pulsar 'Jugar' con el tbUser vacio
		/// </summary>
		private async void showDialog()
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				ContentDialog dialog;
				//ContentDialogResult alse;
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

		/// <summary>
		/// Metodo que suma clicks e invoca al metodo del server 'click'
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainRp_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			if (estado == 3)
			{
				gameVM.points++;
				proxy.Invoke("click");
			}		
		}

		/// <summary>
		/// Metodo que llama al dialogo de puntuaciones y reinicia la partida
		/// </summary>
		/// <param name="listadoJugadores"></param>
		private async void gameEnd(List<clsPlayer> listadoJugadores)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				playEndSound();
				showWinnerDialog(listadoJugadores);
				estado = 0;
				reiniciarPartida();
			}
			);
		}

		/// <summary>
		/// Metodo que muestra un dialog con las puntuaciones de la partida
		/// </summary>
		/// <param name="jugadores"></param>
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

		/// <summary>
		/// Metodo que crea una nueva partida
		/// </summary>
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
			player.PlaybackSession.Position = TimeSpan.Zero;
		}

		/// <summary>
		/// Metodo que conecta con el server y realiza llamada a metodos
		/// </summary>
		public void SignalR()
		{
			conn = new HubConnection("http://clickrace.azurewebsites.net/");
			//conn = new HubConnection("http://localhost:58202");
			proxy = conn.CreateHubProxy("gameHub");
			conn.Start();

			//proxy.on llama al metodo del hub que se especifica en las comillas y le dice que corresponde al metodo del cliente tras la coma
			proxy.On<int>("actualizarPlayers", actualizarPlayers);
			proxy.On<int>("gestionPartida", gestionPartida);
			proxy.On<List<clsPlayer>>("gameEnd", gameEnd);
			proxy.On<int>("actualizarTiempo", actualizarTiempo);
			proxy.On<int>("actualizarPuntos", actualizarPuntos);
			proxy.On<int>("actualizarMaxPlayers", actualizarMaxPlayers);
		}

		/// <summary>
		/// Metodo para actualizar el numero de jugadores conectados y limitarlos a 4
		/// </summary>
		/// <param name="players"></param>
		public async void actualizarPlayers(int players)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				gameVM.jugadoresConectados = players;
				if (players >= gameVM.maxPlayers && gameVM.player.Username != "")
					btnSend.IsEnabled = false;
				else
				{
					if(players < gameVM.maxPlayers  && tbUser.Text == "")
						btnSend.IsEnabled = true;
				}
					
			}
			);
		}

		/// <summary>
		/// Metodo que actualiza el tiempo de partida
		/// </summary>
		/// <param name="tiempo"></param>
		public async void actualizarTiempo(int tiempo)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				gameVM.counter = tiempo;
			}
			);
		}

		/// <summary>
		/// Metodo que actualiza los puntos del usuario
		/// </summary>
		/// <param name="puntos"></param>
		public async void actualizarPuntos(int puntos)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				gameVM.player.points = puntos;
			}
			);
		}

		/// <summary>
		/// Metodo que gestiona el inicio de la partida
		/// </summary>
		/// <param name="estado"></param>
		public async void gestionPartida(int estado)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				this.estado = estado;
				if (estado == 0)
				{
					playStartSound();
					img1.Source = new BitmapImage(new Uri("ms-appx:///Assets/yellow.png"));
				}
					
				if (estado == 1)
				{
					img2.Source = new BitmapImage(new Uri("ms-appx:///Assets/yellow.png"));
				}
					
				if (estado == 2)
				{
					img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/yellow.png"));
				}
					
				if (estado == 3)
				{
					img1.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
					img2.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
					img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
					img3.Source = new BitmapImage(new Uri("ms-appx:///Assets/green.png"));
					playRaceSound();
				}
			});	
		}

		public async void actualizarMaxPlayers(int maxPlayers)
		{
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
			() =>
			{
				gameVM.maxPlayers = maxPlayers;
			}
			);
		}

		public async void playStartSound()
		{
			var element = new MediaElement();
			var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
			var file = await folder.GetFileAsync("sonido2.wav");
			var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
			element.SetSource(stream, "");
			element.Play();
		}

		public async void playRaceSound()
		{
			var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
			var file = await folder.GetFileAsync("race2.wav");
			var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
			element.SetSource(stream, file.ContentType);
			element.Play();
		}

		public async void playEndSound()
		{
			player.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/end.wav"));
			player.Play();
		}
	}
}
