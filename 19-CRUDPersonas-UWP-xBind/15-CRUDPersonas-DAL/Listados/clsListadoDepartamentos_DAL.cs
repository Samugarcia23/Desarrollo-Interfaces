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
	public class clsListadoDepartamentos_DAL
	{
		public List<clsDepartamento> listadoCompletoDepartamentos()
		{
			clsDepartamento oDepartamento;
			List<clsDepartamento> lista = new List<clsDepartamento>();
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				sqlConnection = miConexion.getConnection();
				comando.CommandText = "SELECT nombreDepartamento, idDepartamento FROM Departamentos";
				comando.Connection = sqlConnection;
				lector = comando.ExecuteReader();

				if (lector.HasRows)
				{
					while (lector.Read())
					{
						oDepartamento = new clsDepartamento();
						oDepartamento.nombreDepartamento = (string)lector["nombreDepartamento"];
						oDepartamento.idDepartamento = (int)lector["idDepartamento"];
						lista.Add(oDepartamento);
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

			return lista;
		}
	}
}
