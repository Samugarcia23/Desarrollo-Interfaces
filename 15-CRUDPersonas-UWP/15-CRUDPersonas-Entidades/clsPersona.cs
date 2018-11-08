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
		public clsPersona(int idPersona, String nombre, String apellidos, DateTime fechNacimiento, String direccion, String telefono, int idDepartamento)
		{
			this.idPersona = idPersona;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechNacimiento = fechNacimiento.Date;
			this.direccion = direccion;
			this.telefono = telefono;
			this.idDepartamento = idDepartamento;
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