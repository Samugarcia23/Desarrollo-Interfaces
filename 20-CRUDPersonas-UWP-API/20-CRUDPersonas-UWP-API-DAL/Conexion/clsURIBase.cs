using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUDPersonas_UWP_API_DAL.Conexion
{
	public class clsUriBase
	{
		private static String _uri = "http://localhost:52887/api/";

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
