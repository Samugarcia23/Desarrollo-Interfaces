using _17_Examen1EVAL_UWP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _17_Examen1EVAL_UWP.ViewModels
{
	public class MainPageViewModel : clsVMBase
	{
		#region Propiedades Privadas

		private Uri _imagenCarta;
		private tipoCarta _tipoCarta;
		private int _aciertos;
		private clsCarta _cartaSeleccionada;
		private List<clsCarta> _listadoCartas;
		private DelegateCommand _nuevaPartida;
		private DelegateCommand _funcionalidadPartida;

		#endregion

		#region Propiedades Públicas

		public event PropertyChangedEventHandler PropertyChanged;

		public clsCarta cartaSeleccionada
		{
			get { return _cartaSeleccionada; }
			set
			{
				_cartaSeleccionada = value;
				NotifyPropertyChanged("cartaSeleccionada");
			}
		}

		public List<clsCarta> listadoCartas
		{
			get { return _listadoCartas; }
			set
			{
				_listadoCartas = value;
				NotifyPropertyChanged("listadoCartas");
			}
		}

		public int aciertos
		{
			get { return _aciertos; }
			set
			{
				_aciertos = value;
				NotifyPropertyChanged("aciertos");
			}
		}

		public tipoCarta tipoCarta
		{
			get { return _tipoCarta; }
			set { _tipoCarta = value; }
		}

		public Uri imagenCarta
		{
			get { return _imagenCarta; }
			set { _imagenCarta = value; NotifyPropertyChanged("imagenCarta"); }
		}

		#endregion

		#region Constructores

		public MainPageViewModel()
		{
			rellenarTablero();
		}

		#endregion

		#region Otros Metodos

		public DelegateCommand nuevaPartida
		{
			get
			{
				_nuevaPartida = new DelegateCommand(nuevaPartida_Executed);
				return _nuevaPartida;
			}
		}

		public void nuevaPartida_Executed()
		{
			_cartaSeleccionada = null;
			_aciertos = 0;
			_listadoCartas = clsListadoCartas.listadoCartas();
			NotifyPropertyChanged("cartaSeleccionada");
			NotifyPropertyChanged("aciertos");
		}

		public void rellenarTablero()
		{
			clsCarta carta;
			List<clsCarta> lista = new List<clsCarta>(); 
			Random random;
			for (int i = 0; i < 16; i++)
			{
				random = new Random();
				int numRnd = random.Next(1, 2);
				if (numRnd == 1) { _tipoCarta = tipoCarta.acierto; }
				else
				{
					if (numRnd == 2) { _tipoCarta = tipoCarta.bomba; }
				}
				_imagenCarta = new Uri("ms-appx://_17_Examen1EVAL_UWP/Assets/presionar.png", UriKind.RelativeOrAbsolute);
				carta = new clsCarta(_tipoCarta, _imagenCarta);
				lista.Add(carta);
			}
			_listadoCartas = lista;
		}

		public DelegateCommand funcionalidadPartida
		{
			get
			{
				_funcionalidadPartida = new DelegateCommand(funcionalidadPartida_Executed);
				return _funcionalidadPartida;
			}
		}

		public async void funcionalidadPartida_Executed()
		{
			ContentDialog dialog = new ContentDialog(); 
			ContentDialogResult result;

			do
			{
				if (_tipoCarta == tipoCarta.acierto)
				{
					_imagenCarta = new Uri("ms-appx://_17_Examen1EVAL_UWP/Assets/salvado.png", UriKind.RelativeOrAbsolute);
					_aciertos++;
					NotifyPropertyChanged("aciertos");
				}
				else
				{
					if (_tipoCarta == tipoCarta.bomba)
					{
						_imagenCarta = new Uri("ms-appx://_17_Examen1EVAL_UWP/Assets/salvado.png", UriKind.RelativeOrAbsolute);
						dialog.Title = "BOOOOOOOM!!!";
						dialog.Content = "Has Perdido, ¿Jugar Nueva Partida?";
						dialog.PrimaryButtonText = "No";
						dialog.SecondaryButtonText = "Sí";

						result = await dialog.ShowAsync();
						if (result == ContentDialogResult.Secondary)
						{
							nuevaPartida_Executed();
						}
					}
				}
			} while (_aciertos != 5);

			if (_aciertos == 5)
			{
				dialog.Title = "Enhorabuena!!!";
				dialog.Content = "Has Ganado, ¿Jugar Nueva Partida?";
				dialog.PrimaryButtonText = "No";
				dialog.SecondaryButtonText = "Sí";

				result = await dialog.ShowAsync();
				if (result == ContentDialogResult.Secondary)
				{
					nuevaPartida_Executed();
				}
			}
		}

		#endregion


	}
}
