using _16_RepasoExamenLOL_DAL.Listados;
using _16_RepasoExamenLOL_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_RepasoExamenLOL_BL.Listados
{
	public class clsListadoPersonajes_BL
	{
		public List<clsPersonaje> listadoNombresPersonajes()
		{
			clsListadoPersonajes_DAL listadoPersonajes_DAL = new clsListadoPersonajes_DAL();
			List<clsPersonaje> listadoPersonajes_BL = new List<clsPersonaje>();
			listadoPersonajes_BL = listadoPersonajes_DAL.ListadoNombresPersonajes();

			return listadoPersonajes_BL;
		}
	}
}
