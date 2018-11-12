using _15_CRUDPersonas_Entidades;
using _15_CRUDPersonas_UI.Conexiones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonas_DAL.Manejadoras
{
	public class clsManejadoraPersona_DAL
	{
		/// <summary>
		/// Metodo para borrar una persona pasandole su id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>filas</returns>
		public int BorrarPersonaPorID(int id)
		{
			clsPersona oPersona = new clsPersona();
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			int filas;

			try
			{
				//Obtener conexion abierta	
				sqlconnection = miconexion.getConnection();

				//Definimos los parametros del comando
				sqlCommand.CommandText = "DELETE FROM Personas WHERE idPersona=@id";

				/* 
				 * Definimos el parametro @id
				 */
				SqlParameter param;
				param = new SqlParameter();
				param.ParameterName = "@id";
				param.SqlDbType = System.Data.SqlDbType.Int;
				param.Value = id;

				sqlCommand.Parameters.Add(param);

				//Definir la conexion
				sqlCommand.Connection = sqlconnection;

				//Ejecutar la sentencia
				filas = sqlCommand.ExecuteNonQuery();

			}
			catch (SqlException e) { throw e; }
			finally
			{
				miconexion.closeConnection(ref sqlconnection);
			}
			return filas;
		}
	}
}
