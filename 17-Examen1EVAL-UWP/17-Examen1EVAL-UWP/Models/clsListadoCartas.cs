using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Examen1EVAL_UWP.Models
{
    public class clsListadoCartas
    {
		public static List<clsCarta> listadoCartas()
		{
			List<clsCarta> listado = new List<clsCarta>();
			for (int i = 0; i<16; i++)
				listado.Add(new clsCarta());
			return listado;
		}
    }
}
