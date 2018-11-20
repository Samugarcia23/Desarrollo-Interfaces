using _16_RepasoExamenLOL_DAL.Conexiones;
using _16_RepasoExamenLOL_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_RepasoExamenLOL_DAL.Listados
{
	public class clsListadoCategorias_DAL
	{
		public List<clsCategoria> listadoCompletoCategorias()
		{
			List<clsCategoria> listado = new List<clsCategoria>();
			clsCategoria oCategoria;
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			//Abrimos una nueva conexion
			sqlConnection = miConexion.getConnection();

			//Creamos una nueva sentencia a traves del CommandText
			comando.CommandText = "SELECT idCategoria, nombreCategoria FROM Categorias";
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
					oCategoria = new clsCategoria();
					oCategoria.nombreCategoria = (string)lector["nombreCategoria"];
					oCategoria.idCategoria = (int)lector["idCategoria"];
					listado.Add(oCategoria);
				}
			}

			//Cerramos el lector y la conexion
			lector.Close();
			miConexion.closeConnection(ref sqlConnection);
			//Retornamos la lista
			return listado;
		}
	}
}
