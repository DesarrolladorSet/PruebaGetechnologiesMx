using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Frontend
{
	internal class Service
	{
		private const string BASE_URI = "https://localhost:7023";
		/// <summary>  
		/// Adds new employee  
		/// </summary>  
		public Task<HttpResponseMessage> CreatePersona(Persona persona)
		{
			try
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				string apiUrl = BASE_URI + "/CreatePersona";
				using (HttpClient client = new HttpClient())
				{
					client.BaseAddress = new Uri(apiUrl);
					client.Timeout = TimeSpan.FromSeconds(900);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var response = client.PostAsJsonAsync(apiUrl, persona);
					response.Wait();
					return response;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
