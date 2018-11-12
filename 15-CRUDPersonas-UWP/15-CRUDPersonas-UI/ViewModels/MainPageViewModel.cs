using _15_CRUDPersonas_BL.Listados;
using _15_CRUDPersonas_BL.Manejadoras;
using _15_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _15_CRUDPersonas_UI.ViewModels
{
	public class MainPageViewModel : clsVMBase
	{
		#region Propiedades Privadas
		private clsPersona _PersonaSeleccionada;
		private List<clsPersona> _ListadoDePersonas;
		private List<clsDepartamento> _ListadoDeDepartamentos;
		private clsDepartamento _DepartamentoSeleccionado;
		private DelegateCommand _eliminarCommand;
		private DelegateCommand _actualizarListaCommand;
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
			set { _ListadoDeDepartamentos = value; }
		}

		public clsPersona PersonaSeleccionada
		{
			get { return _PersonaSeleccionada; }
			set
			{
				_PersonaSeleccionada = value;

				//Llamamos a canExxecute de eliminar para que comprube si habilita el comando
				_eliminarCommand.RaiseCanExecuteChanged();
				NotifyPropertyChanged("PersonaSeleccionada");
			}
		}

		public clsDepartamento DepartamentoSeleccionado
		{
			get { return _DepartamentoSeleccionado; }
			set { _DepartamentoSeleccionado = value; NotifyPropertyChanged("DepartamentoSeleccionado"); }
		}

		/// <summary>
		/// Comando Para eliminar
		/// </summary>
		public DelegateCommand eliminarCommand
		{
			get
			{
				_eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
				return _eliminarCommand;
			}
		}

		/// <summary>
		/// Comando para actualizar
		/// </summary>
		public DelegateCommand actualizarListaCommand
		{
			get
			{
				_actualizarListaCommand = new DelegateCommand(ActualizarListaCommand_Executed);
				return _actualizarListaCommand;
			}
		}

		#endregion

		#region Constructores
		public MainPageViewModel()
		{
			ActualizarListaCommand_Executed();
			_ListadoDePersonas = listadoPersonas_BL.listado();
			_ListadoDeDepartamentos = listadoDepartamentos_BL.listado();
		}

		#endregion

		/// <summary>
		/// Metodo que crea un nuevo PropertyChangedEventArgs para realizar el cambio en los datos del formulario
		/// </summary>
		/// <param name="nombre"></param>
		#region Otros
		//protected void NotifyPropertyChanged(string nombre)
		//{
		//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
		//}

		public async void EliminarCommand_Executed()
		{
			int filas;
			ContentDialog confirmarBorrado = new ContentDialog();
			ContentDialogResult resultado;

			confirmarBorrado.Title = "Eliminar";
			confirmarBorrado.Content = "¿Estas seguro?";
			confirmarBorrado.PrimaryButtonText = "Cancelar";
			confirmarBorrado.SecondaryButtonText = "Confirmar";

			resultado = await confirmarBorrado.ShowAsync();
			if(resultado == ContentDialogResult.Secondary)
			{
				try //Vamos a llamar a la capa BL
				{
					//Instancia un objeto de la manejadora de la capa BL
					filas = manejadora_BL.BorrarPersonaPorID_BL(PersonaSeleccionada.idPersona);
					if (filas == 1)
					{
						clsListadoPersonas_BL oListado = new clsListadoPersonas_BL();
						_ListadoDePersonas = oListado.listado();
						NotifyPropertyChanged("ListadoDePersonas");
					}
				}
				catch (Exception e)
				{//TODO lanzar un dialog con error

				}
			}
			
			#endregion
		}

		/// <summary>
		/// Devuelve un booleano parra habilitar/deshabilitar los controles enlazados al comando eliminar
		/// </summary>
		/// <returns></returns>
		private bool EliminarCommand_CanExecute()
		{
			bool sePuedeEliminar = false;
			if(_PersonaSeleccionada != null)
			{
				sePuedeEliminar = true;
			}
			return sePuedeEliminar;
		}

		/// <summary>
		/// Carga la lista de nuevo
		/// </summary>
		public void ActualizarListaCommand_Executed()
		{
			try
			{
				_ListadoDePersonas = listadoPersonas_BL.listado();
				NotifyPropertyChanged("ListadoDePersonas");
			}
			catch (Exception e)
			{
				//TODO Dialog con Error
			}
		}
	}
}
