using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUDPersonas_UWP_API_DAL.Conexion
{
	public class clsUriBase
	{
		private static String _uri = "https://10-apirestpersonas-sam.azurewebsites.net/api/personas";

		/// <summary>
		/// Devuelve un String con la uri de la API
		/// </summary>
		/// <returns> String con la uri de la API </returns>
		public String uri
		{
			get
			{
				return _uri;
			}
		}
	}
}
