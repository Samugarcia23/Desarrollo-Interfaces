using System;
using System.Collections.Generic;
using System.Linq;

namespace _15_CRUDPersonas_Entidades
{
	public class clsPersona
	{
		#region Constructor por Defecto
		public clsPersona()
		{

		}
		#endregion
		#region Constructor por parametros
		public clsPersona(int idPer, String nom, String ape, DateTime fechNac, String direc, String tel, int idDep)
		{
			this.idPersona = idPer;
			this.nombre = nom;
			this.apellidos = ape;
			this.fechNacimiento = fechNac;
			this.direccion = direc;
			this.telefono = tel;
			this.idDepartamento = idDep;
		}
		#endregion
		#region atributos_Persona
		public int idPersona { get; set; }
		public String nombre { get; set; }
		public String apellidos { get; set; }
		public DateTime fechNacimiento { get; set; }
		public String direccion { get; set; }
		public String telefono { get; set; }
		public int idDepartamento { get; set; }
		#endregion
	}
}