using _20_CRUDPersonas_UWP_API_DAL.Conexion;
using _20_CRUDPersonas_UWP_API_Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUDPersonas_UWP_API_DAL.Listados
{
	public class clsListadoPersonas_DAL
	{
		
		/// <summary>
		/// Funcion que devuelve un listado de personas
		/// </summary>
		/// <returns></returns>
		public async Task<List<clsPersona>> ListadoCompletoPersonas_DAL()
		{
			clsUriBase clsUriBase = new clsUriBase();
			String miURL = clsUriBase.uri;
			Uri uri = new Uri($"{miURL}personas");
			List<clsPersona> listado = new List<clsPersona>();
			HttpClient httpClient = new HttpClient();
			string respuesta;
			try
			{
				respuesta = await httpClient.GetStringAsync(uri);
				httpClient.Dispose();
				listado = JsonConvert.DeserializeObject<List<clsPersona>>(respuesta);
			}
			catch (WebException exception) {  }

			return listado;
		}
	}
}
