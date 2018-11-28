using _15_CRUDPersonas_DAL.Manejadoras;
using _15_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CRUDPersonas_BL.Manejadoras
{
	public class clsManeJadoraPersona_BL
	{
		/// <summary>
		///  Funcion que llama a BorrarPersonaPorID de la capa DAL y devuelve las filas alteradas a la capa UI
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int BorrarPersonaPorID_BL(int id)
		{
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			int filas;
			filas = manejadora_DAL.BorrarPersonaPorID(id);
			return filas;
		}

		public int InsertarPersona_BL(clsPersona oPersona)
		{
			int filas;
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			filas  = manejadora_DAL.InsertarPersona_DAL(oPersona);

			return filas;
		}

		public int EditarPersona_BL(clsPersona oPersona)
		{
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			int filas;
			filas = manejadora_DAL.EditarPersona_DAL(oPersona);
			return filas;
		}
	}
}
