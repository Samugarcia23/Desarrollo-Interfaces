﻿using _20_CRUDPersonas_UWP_API_Entidades;
using _20_CRUDPersonas_UWP_API_UI;
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

namespace _20_CRUDPersonas_UWP_API_UI
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

		private void addPersona_Click(object sender, RoutedEventArgs e)
		{
			//txtNombre.Focus(FocusState.Programmatic);
		}

		private void listaPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		private void listaPersonas_RightTapped(object sender, RightTappedRoutedEventArgs e)
		{
			/*ListView lista = (ListView)sender;
			mflyMenuFlyout.ShowAt(lista, e.GetPosition(lista));
			clsPersona oPersonaSeleccionada = (clsPersona)((FrameworkElement)e.OriginalSource).DataContext;
			this.listaPersonas.SelectedItem = oPersonaSeleccionada;*/
		}
	}
}