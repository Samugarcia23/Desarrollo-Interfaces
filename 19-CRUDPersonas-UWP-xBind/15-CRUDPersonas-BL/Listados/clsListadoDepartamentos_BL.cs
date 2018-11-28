using _15_CRUDPersonas_DAL.Listados;
using _15_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonas_BL.Listados
{
	public class clsListadoDepartamentos_BL
	{
		public List<clsDepartamento> listado()
		{
			List<clsDepartamento> lista_BL = new List<clsDepartamento>();
			clsListadoDepartamentos_DAL lista_DAL = new clsListadoDepartamentos_DAL();
			lista_BL = lista_DAL.listadoCompletoDepartamentos();

			return lista_BL;
		}
	}
}
