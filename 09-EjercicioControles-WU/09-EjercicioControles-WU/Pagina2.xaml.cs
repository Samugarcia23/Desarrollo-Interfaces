using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _09_EjercicioControles_WU
{
	/// <summary>
	/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>
	public sealed partial class Pagina2 : Page
	{
		public Pagina2()
		{
			this.InitializeComponent();
		}
		#region Animacion
		//Funcion que al hacer click en la imagen, nos llevara hacia la pagina donde esta la imagen de destino
		private void SourceImage_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			/*SuppressNavigationTransitionInfo() suprime la animacion por defecto para evitar conflicto con la nueva
			animacion*/
			Frame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());
		}

		/*Funcion que prepara el contexto actual para realizar la animación, forwardAnimation es la animación 
		  hacia delante por defecto (se puede hacer una personalizada)*/
		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			ConnectedAnimationService.GetForCurrentView()
				.PrepareToAnimate("forwardAnimation", SourceImage);
			// Para una animación personalizada, habría que usar:
			// animation.Configuration = new BasicConnectedAnimationConfiguration();
		}
		#endregion

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (Frame.CanGoBack)
				Frame.GoBack();
		}
	}
}
