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
		public clsDepartamento(int id, String nom)
		{
			this.idDepartamento = id;
			this.nombreDepartamento = nom;
		}
		#endregion
		#region atributos_Departamento
		public int idDepartamento { set; get; }
		public String nombreDepartamento { set; get; }
		#endregion
	}
}