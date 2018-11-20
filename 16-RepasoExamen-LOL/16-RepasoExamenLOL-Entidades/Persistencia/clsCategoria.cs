using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_RepasoExamenLOL_Entidades.Persistencia
{
	public class clsCategoria
	{
		#region Constructor por defecto

		public clsCategoria()
		{

		}

		#endregion

		#region Constructor con Parametros

		public clsCategoria(int idCategoria, string nombreCategoria)
		{
			this.idCategoria = idCategoria;
			this.nombreCategoria = nombreCategoria;
		}

		#endregion

		#region Atributos

		public int idCategoria { get; set; }
		public string nombreCategoria { get; set; }

		#endregion
	}
}
