using _20_CRUDPersonas_UWP_API_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUDPersonas_UWP_API_DAL.Listados
{
	public class clsListadoPersonas_BL
	{
		public async Task<List<clsPersona>> listado()
		{
			List<clsPersona> lista_BL = new List<clsPersona>();
			clsListadoPersonas_DAL lista_DAL = new clsListadoPersonas_DAL();
			lista_BL = await lista_DAL.ListadoCompletoPersonas_DAL();
			return lista_BL;
		}
	}
}
