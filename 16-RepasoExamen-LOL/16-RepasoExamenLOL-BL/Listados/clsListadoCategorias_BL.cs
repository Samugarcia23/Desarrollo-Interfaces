using _16_RepasoExamenLOL_DAL.Listados;
using _16_RepasoExamenLOL_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_RepasoExamenLOL_BL.Listados
{
	public class clsListadoCategorias_BL
	{
		public List<clsCategoria> listadoCategoria()
		{
			clsListadoCategorias_DAL listadoCategorias_DAL = new clsListadoCategorias_DAL();
			List<clsCategoria> listadoCategorias_BL = new List<clsCategoria>();
			listadoCategorias_BL = listadoCategorias_DAL.listadoCompletoCategorias();

			return listadoCategorias_BL;
		}
	}
}
