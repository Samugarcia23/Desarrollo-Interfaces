using _14_Ejercicio2Binding_UWP.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_Ejercicio2Binding_UWP.Models.Manejadora
{
	public class clsListadoPersona
	{
		 public static List<clsPersona> listadoPersona()
		 {
			List <clsPersona> listado = new List<clsPersona>();
			listado.Add(new clsPersona(1, "Sam", "Garcia Preciado", new DateTime(1997, 10, 29), "calle 223", "5545656456", 1));
			listado.Add(new clsPersona(1, "Paco", "Cabesa Grande", new DateTime(1997, 10, 29), "calle 23", "55456999456", 2));
			listado.Add(new clsPersona(1, "Pepe", "Cordoba ", new DateTime(1997, 10, 29), "calle gr", "5545656456", 3));
			listado.Add(new clsPersona(1, "Yoquese", "Apellido", new DateTime(1997, 10, 29), "calle 22sdfas3", "554456456", 4));
			return listado;
		 }
	}
}