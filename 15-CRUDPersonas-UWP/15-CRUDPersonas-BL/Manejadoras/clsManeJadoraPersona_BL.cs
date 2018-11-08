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
		public clsDepartamento DepartamentoPorIDPersona(int id)
		{
			clsDepartamento oDepartamento = new clsDepartamento();
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();

			oDepartamento = manejadora_DAL.DepartamentoPorIDPersona(oPersona.idPersona);

			return oDepartamento;
		}
	}
}
