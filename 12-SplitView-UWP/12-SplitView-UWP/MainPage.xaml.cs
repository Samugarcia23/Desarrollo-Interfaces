using _12_SplitView_UWP.Views;
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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _12_SplitView_UWP
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

		private void btnHome_Click(object sender, RoutedEventArgs e)
		{
			contenedor.Navigate(typeof(Pagina1));
		}

		private void btnMensajes_Click(object sender, RoutedEventArgs e)
		{
			contenedor.Navigate(typeof(Pagina2));
		}

		private void btnAvisos_Click(object sender, RoutedEventArgs e)
		{
			contenedor.Navigate(typeof(Pagina3));
		}

		private void btnContactos_Click(object sender, RoutedEventArgs e)
		{
			contenedor.Navigate(typeof(Pagina4));
		}

		private void HamburgerButton_Click(object sender, RoutedEventArgs e)
		{
			splView.IsPaneOpen = !splView.IsPaneOpen;
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (btnPagina1.IsSelected)
			{
				btnHome_Click(sender, e);
			}
			else
			{
				if (btnPagina2.IsSelected)
				{
					btnMensajes_Click(sender, e);
				}
				else
				{
					if (btnPagina3.IsSelected)
					{
						btnAvisos_Click(sender, e);
					}
					else
					{
						if (btnPagina4.IsSelected)
						{
							btnContactos_Click(sender, e);
						}
					}
				}
			}
		}
	}
}
