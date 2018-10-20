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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _09_EjercicioControles_WU
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(Pagina2));
		}

		#region Animación 

		/*Método que conecta la imagen que realizará la animación con la imagen de destino*/
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			//Base representa el contenido al que puede navegar un control "Frame"
			base.OnNavigatedTo(e);

			/*Se obtiene la animación que hemos creado anteriormente y si no es NULL entonces se utiliza 
			 TryStart(), pasándole el nombre de la imagen destino para comenzar*/
			ConnectedAnimation animation =
			ConnectedAnimationService.GetForCurrentView().GetAnimation("forwardAnimation");
			if (animation != null)
			{
				animation.TryStart(DestinationImage);
			}
		}
		#endregion

	}
}

/*Principal uso de las Animaciones Conectadas:
 * 
 * Las animaciones conectadas permiten crear una experiencia de navegación dinámica y atractiva al animar 
 * la transición de un elemento entre dos vistas distintas. 
 * Esto ayuda al usuario a mantener el contexto y ofrece continuidad entre las vistas.
 * En una animación conectada, un elemento parece "Continuar" entre dos vistas durante un cambio 
 * en el contenido de la interfaz de usuario, volando por la pantalla desde su ubicación en la vista de origen 
 * hasta su destino en la nueva vista.
 * Esto enfatiza el contenido común entre las vistas y 
 * crea un efecto atractivo y dinámico como parte de una transición.
 * 
 */
