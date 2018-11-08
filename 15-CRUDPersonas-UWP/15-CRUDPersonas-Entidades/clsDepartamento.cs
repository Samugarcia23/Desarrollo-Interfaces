using System;
using System.Collections.Generic;
using System.Linq;

namespace _15_CRUDPersonas_Entidades
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