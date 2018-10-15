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

namespace _07_GridForm_WU
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
		/// Evento asociado al click del boton enviar. Valida el formulario y escribe mensajes de errores.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnEnviar_Click(object sender, RoutedEventArgs e)
		{
			//Declaracion de variables
			String nombre, apellido, edad, email, fecha;
			nombre = txbNombre.Text;
			apellido = txbApellido.Text;
			edad = txbEdad.Text;
			fecha = txbFecha.Text;
			email = txbEmail.Text;
			Boolean error = false;

			//Validacion del nombre, si esta vacio escribe un error
			if (String.IsNullOrEmpty(nombre))
			{
				txtErrorNom.Text = "Error, introduce tu Nombre";
				error = true;
			}
			else
			{
				txtErrorNom.Text = "";
			}

			//Validacion del apellido, si esta vacio escribe un error
			if (String.IsNullOrEmpty(apellido))
			{
				txtErrorApe.Text = "Error, introduce tu Apellido";
				error = true;
			}
			else
			{
				txtErrorApe.Text = "";
			}

			//Validacion de la edad, si esta vacio escribe un error
			if (String.IsNullOrEmpty(edad))
			{
				txtErrorEdad.Text = "Error, introduce tu Edad";
				error = true;
			}
			else
			{
				txtErrorEdad.Text = "";
			}

			//Validacion de la fecha, si no tiene un formato correcto, devuelve un error
			if (!fechaValida(fecha))
			{
				txtErrorFecha.Text = "Error, introduce una fecha correcta";
				error = true;
			}
			else
			{
				txtErrorFecha.Text = "";
			}

			//Validacion del email, si no tiene un formato correcto, devuelve un error
			if (!emailValido(email))
			{
				txtErrorEmail.Text = "Error, introduce un email correcto";
				error = true;
			}
			else
			{
				txtErrorEmail.Text = "";
			}


			//Pop up para indicar que no ha habido errores
			if (error == false)
			{
				MessageDialog msgbox = new MessageDialog($"Enviado Correctamente");
				msgbox.Commands.Clear();
				msgbox.Commands.Add(new UICommand { Label = "Salir", Id = 0 });
				var res = await msgbox.ShowAsync();
				borrar();
			}
		}

		public Boolean fechaValida(String fecha)
		{
			bool ret = false;
			DateTime value;
			if (DateTime.TryParse(txbFecha.Text, out value)) ret = true;
			return ret;
		}

		public Boolean emailValido(String mail)
		{
			bool ret = false;
			System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
			if (expr.IsMatch(txbEmail.Text)) ret = true;
			else ret = false;
			return ret;
		}

		public void borrar()
		{
			txbNombre.Text = "";
			txbEdad.Text = "";
			txbApellido.Text = "";
			txbEmail.Text = "";
			txbFecha.Text = "";
			txtErrorApe.Text = "";
			txtErrorNom.Text = "";
			txtErrorEdad.Text = "";
			txtErrorEmail.Text = "";
			txtErrorFecha.Text = "";
		}
	}
}



