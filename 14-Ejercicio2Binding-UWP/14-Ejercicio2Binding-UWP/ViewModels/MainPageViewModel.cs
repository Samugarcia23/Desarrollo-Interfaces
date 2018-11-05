using _14_Ejercicio2Binding_UWP.Models.Entidades;
using _14_Ejercicio2Binding_UWP.Models.Manejadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Ejercicio2Binding_UWP.ViewModels
{
	public class MainPageViewModel
	{
		#region Propiedades Privadas
		private List<clsPersona> _ListadoDePersonas;
		private clsPersona _PersonaSeleccionada;
		private List<clsDepartamento> _ListadoDepartamentos;
		#endregion

		#region Propiedades Publicas

		public List<clsPersona> ListadoDePersonas
		{
			get { return _ListadoDePersonas; }
			set { _ListadoDePersonas = value; }
		}

		public clsPersona PersonaSeleccionada
		{
			get { return _PersonaSeleccionada; }
			set { _PersonaSeleccionada = value; }
		}

		public List<clsDepartamento> ListadoDepartamentos
		{
			get { return _ListadoDepartamentos; }
			set { _ListadoDepartamentos = value; }
		}

		#endregion

		#region Constructores
		public MainPageViewModel()
		{
			//Cargar el listado de Personas
			_ListadoDePersonas = clsListadoPersona.listadoPersona();
		}

		#endregion


	}
}
