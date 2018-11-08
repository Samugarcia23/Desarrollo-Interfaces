using _15_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonas_UI.ViewModels
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		#region Propiedades Privadas
		private List<clsPersona> _ListadoDePersonas;
		private clsPersona _PersonaSeleccionada;
		private List<clsDepartamento> _ListadoDepartamentos;
		#endregion

		#region Propiedades Publicas

		public event PropertyChangedEventHandler PropertyChanged;

		public List<clsPersona> ListadoDePersonas
		{
			get { return _ListadoDePersonas; }
			set { _ListadoDePersonas = value; }
		}

		public clsPersona PersonaSeleccionada
		{
			get { return _PersonaSeleccionada; }
			set { _PersonaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }
		}

		public List<clsDepartamento> ListadoDepartamentos
		{
			get { return _ListadoDepartamentos; }
			set { _ListadoDepartamentos = value;}	
		}

		#endregion

		#region Constructores
		public MainPageViewModel()
		{
			//Cargar el listado de Personas
			//_ListadoDePersonas = Listado de la capa bl .listadoPersona();
		}

		#endregion

		/// <summary>
		/// Metodo que crea un nuevo PropertyChangedEventArgs para realizar el cambio en los datos del formulario
		/// </summary>
		/// <param name="nombre"></param>
		#region Otros
		protected void NotifyPropertyChanged(string nombre)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
		}
		#endregion

	}
}
