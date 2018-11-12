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

		public int InsertarPersona_DAL(clsPersona oPersona)
		{
			int filas;
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand comando = new SqlCommand();

			try
			{
				sqlConnection = miConexion.getConnection();

				comando.CommandText = "INSERT INTO Personas(nombrePersona, apellidosPersona, fechaNacimiento, direccion, telefono, idDepartamento) " +
					"VALUES (@nombre, @apellidos, @fechaNac, @direccion, @telefono, @departamento)";

				//Definicion de parametros
				comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.nombre;
				comando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = oPersona.apellidos;
				comando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = oPersona.fechNacimiento;
				comando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.direccion;
				comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.telefono;
				comando.Parameters.Add("@departamento", System.Data.SqlDbType.Int).Value = oPersona.idDepartamento;

				comando.Connection = sqlConnection;

				filas = comando.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw e;
			}
			finally
			{
				miConexion.closeConnection(ref sqlConnection);
			}

			return filas;
		}

		public int EditarPersona_DAL(clsPersona persona)
		{
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			int filas;

			try
			{
				sqlconnection = miconexion.getConnection();

				sqlCommand.CommandText = "UPDATE Personas SET nombrePersona = @nombre, apellidosPersona = @apellidos, fechaNacimiento = @fechaNac, direccion = @direccion, telefono = @telefono, idDepartamento = @departamento WHERE idPersona = @id";

				sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
				sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
				sqlCommand.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
				sqlCommand.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.fechNacimiento;
				sqlCommand.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
				sqlCommand.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;
				sqlCommand.Parameters.Add("@departamento", System.Data.SqlDbType.Int).Value = persona.idDepartamento;

				sqlCommand.Connection = sqlconnection;

				filas = sqlCommand.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw e;
			}
			finally
			{
				miconexion.closeConnection(ref sqlconnection);
			}

			return filas;
		}

	}
}
