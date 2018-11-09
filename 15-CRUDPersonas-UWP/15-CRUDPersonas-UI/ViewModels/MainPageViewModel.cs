using _15_CRUDPersonas_BL.Listados;
using _15_CRUDPersonas_BL.Manejadoras;
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
		private clsPersona _PersonaSeleccionada;
		private List<clsPersona> _ListadoDePersonas;
		private List<clsDepartamento> _ListadoDeDepartamentos;
		private clsDepartamento _DepartamentoSeleccionado;
		#endregion

		#region Propiedades Publicas

		public event PropertyChangedEventHandler PropertyChanged;
		clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();
		clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();
		clsManeJadoraPersona_BL manejadora_BL = new clsManeJadoraPersona_BL();

		public List<clsPersona> ListadoDePersonas
		{
			get { return _ListadoDePersonas; }
			set { _ListadoDePersonas = value; }
		}

		public List<clsDepartamento> ListadoDeDepartamentos
		{
			get { return _ListadoDeDepartamentos; }
			set { _ListadoDeDepartamentos = value; NotifyPropertyChanged("PersonaSeleccionada"); }
		}

		public clsPersona PersonaSeleccionada
		{
			get { return _PersonaSeleccionada; }
			set { _PersonaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }
		}

		public clsDepartamento DepartamentoSeleccionado
		{
			get { return _DepartamentoSeleccionado; }
			set { _DepartamentoSeleccionado = value;  }
			// _DepartamentoSeleccionado = manejadora_BL.DepartamentoPorIDPersona(PersonaSeleccionada.idPersona)
		}

		#endregion

		#region Constructores
		public MainPageViewModel()
		{
			_ListadoDePersonas = listadoPersonas_BL.listado();
			_ListadoDeDepartamentos = listadoDepartamentos_BL.listado();
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
