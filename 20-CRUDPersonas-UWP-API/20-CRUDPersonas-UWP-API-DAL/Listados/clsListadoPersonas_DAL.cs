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
			clsUriBase getUri = new clsUriBase();
			List<clsPersona> listado = null;
			try
			{
				using (HttpClient client = new HttpClient())
				{
					Uri myUri = new Uri(getUri.uri, UriKind.Absolute);
					client.BaseAddress = myUri;
					var data = await client.GetAsync(string.Concat(myUri, "routeName"));
					var jsonResponse = await data.Content.ReadAsStringAsync();
					HttpResponseMessage response = await client.GetAsync("personas");
					if (jsonResponse != null)
						listado = JsonConvert.DeserializeObject<List<clsPersona>>(jsonResponse);
					return listado;
				}
			}
			catch (WebException exception) { throw new WebException("An error has occurred while calling GetSampleClass method: " + exception.Message); }	
		}
	}
}
