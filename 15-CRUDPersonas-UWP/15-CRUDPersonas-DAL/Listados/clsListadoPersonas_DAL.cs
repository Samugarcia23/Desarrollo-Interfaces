using _15_CRUDPersonas_Entidades;
using _15_CRUDPersonas_UI.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonas_DAL.Listados
{
	public class clsListadoPersonas_DAL
	{
		/// <summary>
		/// Funcion que devuelve un List<> de objetos persona (Select a la BD)
		/// </summary>
		/// <returns>List</returns>
		public List<clsPersona> listadoCompletoPersonas()
		{

			clsPersona oPersona;
			List<clsPersona> listado = new List<clsPersona>();
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = null;
			SqlDataReader lector = null;
			SqlCommand comando = new SqlCommand();

			try
			{	
				//Conectamos con nuestra BD
				sqlConnection = miConexion.getConnection();
				comando.CommandText = "SELECT * FROM Personas";
				comando.Connection = sqlConnection;
				lector = comando.ExecuteReader();

				if (lector.HasRows)
				{
					while (lector.Read())
					{
						oPersona = new clsPersona();
						oPersona.idPersona = (int)lector["idPersona"];
						oPersona.nombre = (string)lector["nombrePersona"];
						oPersona.apellidos = (string)lector["apellidosPersona"];
						oPersona.fechNacimiento = (DateTime)lector["fechaNacimiento"];
						oPersona.direccion = (string)lector["direccion"];
						oPersona.telefono = (string)lector["telefono"];
						oPersona.idDepartamento = (int)lector["idDepartamento"];
						listado.Add(oPersona);
					}
				}
			}
			catch (SqlException e) { throw e; }
			finally
			{
				miConexion.closeConnection(ref sqlConnection);
				if (lector != null)
					lector.Close();
			}
			return listado;
		}
	}
}
