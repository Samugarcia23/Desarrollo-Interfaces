using _15_CRUDPersonas_DAL.Listados;
using _15_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonas_BL.Listados
{
	public class clsListadoPersonas_BL
	{
		public List<clsPersona> listado()
		{
			List<clsPersona> lista_BL = new List<clsPersona>();
			clsListadoPersonas_DAL lista_DAL = new clsListadoPersonas_DAL();
			lista_BL = lista_DAL.listadoCompletoPersonas();
			return lista_BL;
		}
	}
}
