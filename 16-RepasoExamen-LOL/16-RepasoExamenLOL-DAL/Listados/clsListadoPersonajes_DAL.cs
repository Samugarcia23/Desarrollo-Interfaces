using _16_RepasoExamenLOL_Entidades.Persistencia;
using _16_RepasoExamenLOL_DAL.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_RepasoExamenLOL_DAL.Listados
{
	public class clsListadoPersonajes_DAL
	{
		/// <summary>
		/// Metodo que devuelve un listado con los nombres de los personajes
		/// </summary>
		/// <returns>listadoNombres</returns>
		public List<clsPersonaje> ListadoNombresPersonajes()
		{
			//Declaraciones
			clsPersonaje oPersonaje;
			List<clsPersonaje> listadoNombres = new List<clsPersonaje>();
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			//Abrimos una nueva conexion
			sqlConnection = miConexion.getConnection();

			//Creamos una nueva sentencia a traves del CommandText
			comando.CommandText = "SELECT Nombre, idPersonaje, alias FROM Personajes";
			//Asignamos la conexion al comando
			comando.Connection = sqlConnection;
			//Asignamos el lector al comando
			lector = comando.ExecuteReader();

			//Si hay filas...
			if (lector.HasRows)
			{
				//Mientras que el lector pueda "leer"...
				while (lector.Read())
				{
					//Creamos un nuevo personaje con su atributo "nombre"
					oPersonaje = new clsPersonaje();
					oPersonaje.nombre = (string)lector["nombre"];
					oPersonaje.idPersonaje = (int)lector["idPersonaje"];
					oPersonaje.alias = (string)lector["alias"];
					//Agregamos dicho personaje a la lista de nombres
					listadoNombres.Add(oPersonaje);
				}
			}

			//Cerramos el lector y la conexion
			lector.Close();
			miConexion.closeConnection(ref sqlConnection);
			//Retornamos la lista
			return listadoNombres;
		}
	}
}
