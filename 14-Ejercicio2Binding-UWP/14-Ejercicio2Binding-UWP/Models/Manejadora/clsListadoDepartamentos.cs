using _14_Ejercicio2Binding_UWP.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_Ejercicio2Binding_UWP.Models.Manejadora
{
	//Hay que crearlo en una carpeta llamada DAL(Acceso de datos)
	public class clsListadoDepartamentos
	{
		public static List<clsDepartamento> listadoDepartamentos()
		{
			List<clsDepartamento> listado = new List<clsDepartamento>();
			listado.Add(new clsDepartamento(1, "Informatica"));
			listado.Add(new clsDepartamento(2, "Ciencias"));
			listado.Add(new clsDepartamento(3, "Historia"));
			listado.Add(new clsDepartamento(4, "Lengua"));
			return listado;
		}
	}
}