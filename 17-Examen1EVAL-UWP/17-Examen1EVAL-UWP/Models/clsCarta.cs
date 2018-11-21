using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Examen1EVAL_UWP.Models
{
	public class clsCarta
	{
		#region Atributos

		public tipoCarta tipoCarta;
		public Uri imagen { get; set; }

		#endregion

		#region Constructor por defecto

		public clsCarta()
		{

		}

		#endregion

		#region Constructor por parámetros

		public clsCarta(tipoCarta tipo, Uri imagen)
		{
			this.imagen = imagen;
			this.tipoCarta = tipo;
		}

		#endregion
	}

	public enum tipoCarta
	{
		bomba, acierto, normal
	}
}
