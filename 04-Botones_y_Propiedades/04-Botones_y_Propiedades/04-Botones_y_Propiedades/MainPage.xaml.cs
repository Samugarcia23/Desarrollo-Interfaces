using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _04_Botones_y_Propiedades
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
			Button btn3;
			btn3 = new Button();
			btn3.Content = "Boton 3";
			btn3.Background = new SolidColorBrush(Colors.Blue);
			btn3.Foreground = new SolidColorBrush(Colors.White);
			btn3.HorizontalAlignment = HorizontalAlignment.Center;
			btn3.VerticalAlignment = VerticalAlignment.Center;
			btn3.Height = 70;
			btn3.Width = 200;
			FontFamily family = new FontFamily("Verdana");
			btn3.FontFamily = family;
			btn3.FontSize = 16;
			btn3.BorderBrush = new SolidColorBrush(Colors.Yellow);
			stackPanel1.Children.Add(btn3);
			btn3.Click += btn3_Click;
		}

		public async void btn3_Click(object sender, RoutedEventArgs e)
		{
			MessageDialog msgbox = new MessageDialog($"Hola, has pulsado el boton 3");

			msgbox.Commands.Clear();
			msgbox.Commands.Add(new UICommand { Label = "Salir", Id = 0 });

			var res = await msgbox.ShowAsync();
			if ((int)res.Id == 0)
			{
				MessageDialog msgbox2 = new MessageDialog("", $"Adios! :)");
				await msgbox2.ShowAsync();
			}
		}
    }
}
