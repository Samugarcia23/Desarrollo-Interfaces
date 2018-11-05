using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_Ejercicio2Binding_UWP.Models.Entidades
{
	public class clsDepartamento
	{
		#region Constructor por Defecto
		public clsDepartamento()
		{

		}
		#endregion
		#region Constructor por parametros
		public clsDepartamento(int idDepartamento, String nombreDepartamento)
		{
			this.idDepartamento = idDepartamento;
			this.nombreDepartamento = nombreDepartamento;
		}
		#endregion
		#region atributos_Departamento
		public int idDepartamento { get; set; }
		public String nombreDepartamento { get; set; }
		#endregion
	}
}