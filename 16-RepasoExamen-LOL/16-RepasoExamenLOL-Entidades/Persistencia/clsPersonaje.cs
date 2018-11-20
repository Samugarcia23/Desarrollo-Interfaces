using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_RepasoExamenLOL_Entidades.Persistencia
{
	public class clsPersonaje
	{
		#region Constructor por defecto

		public clsPersonaje()
		{

		}

		#endregion

		#region Constructor con parametros

		public clsPersonaje(int idPersonaje, string nombre, string alias, double vida, double regeneracion, double danno, double armadura, double velAtaque, double resistencia, double velMovimiento, int idCategoria)
		{
			this.idPersonaje = idPersonaje;
			this.nombre = nombre;
			this.alias = alias;
			this.vida = vida;
			this.regeneracion = regeneracion;
			this.danno = danno;
			this.armadura = armadura;
			this.velAtaque = velAtaque;
			this.resistencia = resistencia;
			this.velMovimiento = velMovimiento;
			this.idCategoria = idCategoria;
		}

		#endregion

		#region Atributos

		public int idPersonaje { get; set; } 
		public string nombre { get; set; }
		public string alias { get; set; }
		public double vida { get; set; }
		public double regeneracion { get; set; }
		public double danno { get; set; }
		public double armadura { get; set; }
		public double velAtaque { get; set; }
		public double resistencia { get; set; }
		public double velMovimiento { get; set; }
		public int idCategoria { get; set; }


		#endregion
	}
}
