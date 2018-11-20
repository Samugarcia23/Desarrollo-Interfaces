using _16_RepasoExamenLOL_BL.Listados;
using _16_RepasoExamenLOL_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_RepasoExamen_LOL.ViewModels
{
	public class MainPageViewModel : clsVMBase
	{
		#region Propiedades Privadas

		private List<clsPersonaje> _listadoPersonajes;
		private List<clsCategoria> _listadoCategorias;
		private clsCategoria _categoriaSeleccionada;
		private clsPersonaje _personajeSeleccionado;

		#endregion

		#region Propiedades Públicas

		public event PropertyChangedEventHandler PropertyChanged;
		clsListadoCategorias_BL listadoCategorias_BL = new clsListadoCategorias_BL();
		clsListadoPersonajes_BL listadoPersonajes_BL = new clsListadoPersonajes_BL();

		public List<clsPersonaje> listadoPersonajes
		{
			get { return _listadoPersonajes; }
			set { _listadoPersonajes = value; }
		}

		public List<clsCategoria> listadoCategorias
		{
			get { return _listadoCategorias; }
			set { _listadoCategorias = value; }
		}

		public clsCategoria categoriaSeleccionada
		{
			get { return _categoriaSeleccionada; }
			set { _categoriaSeleccionada = value; }
		}

		public clsPersonaje personajeSeleccionado
		{
			get { return _personajeSeleccionado; }
			set { _personajeSeleccionado = value; }
		}

		#endregion

		#region Constructores

		public MainPageViewModel()
		{
			_listadoCategorias = listadoCategorias_BL.listadoCategoria();
			_listadoPersonajes = listadoPersonajes_BL.listadoNombresPersonajes();
		}

		#endregion
	}
}
