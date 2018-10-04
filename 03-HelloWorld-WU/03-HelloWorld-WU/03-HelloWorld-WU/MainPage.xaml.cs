using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _03_HelloWorld_WU
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

		/// <summary>
		///		Este metodo lanza un dialog en el que se muestra un nombre escrito en el textbox(tbxNombre)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private async void btnSaludo_Click(object sender, RoutedEventArgs e)
		{
			String nombre;
			nombre = tbxNombre.Text;

			MessageDialog msgbox = new MessageDialog($"Hola {nombre}");

			msgbox.Commands.Clear();
			msgbox.Commands.Add(new UICommand { Label = "Salir", Id = 0 });

			var res = await msgbox.ShowAsync();
			if ((int)res.Id == 0)
			{
				MessageDialog msgbox2 = new MessageDialog("", $"Adios! {nombre} :)");
				await msgbox2.ShowAsync();
			}
		}
	}
}
