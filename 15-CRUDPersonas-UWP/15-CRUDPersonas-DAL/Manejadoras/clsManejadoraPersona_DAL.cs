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
		public clsDepartamento DepartamentoPorIDPersona(int id)
		{
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = null;
			SqlDataReader lector = null;
			SqlCommand comando = new SqlCommand();
			clsDepartamento oDepartamento = new clsDepartamento();
			clsPersona oPersona = new clsPersona();

			try
			{
				sqlConnection = miConexion.getConnection();

				comando.CommandText = "SELECT nombreDepartamento FROM Departamentos INNER JOIN Personas ON Departamentos.IDDepartamento = Personas.IDDepartamento WHERE IDPersona = @id;";

				comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = oPersona.idPersona;
				comando.Connection = sqlConnection;

				lector = comando.ExecuteReader();

				if (lector.HasRows)
				{
					lector.Read();
					oPersona.idPersona = (int)lector["idPersona"];
				}

			}
			catch (SqlException e) { throw e; }
			finally
			{
				miConexion.closeConnection(ref sqlConnection);
				if (lector != null)
					lector.Close();
			}

			return oDepartamento;

		}
	}
}
