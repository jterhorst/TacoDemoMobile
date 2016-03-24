using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TacoDemo
{
	// http://bertt.wordpress.com/2013/03/19/using-geonames-webservices-from-portable-class-library-pcl/

	public class TacosWebService
	{
		public TacosWebService ()
		{
		}

		public async Task<Taco[]> GetTacosAsync () {

			var client = new System.Net.Http.HttpClient ();

			client.BaseAddress = new Uri("http://tacodemo.herokuapp.com/");

			var response = await client.GetAsync("tacos.json");

			var tacosJson = response.Content.ReadAsStringAsync().Result;

			var rootobject = JsonConvert.DeserializeObject<Taco[]>(tacosJson);

			return rootobject;

		}
	}
}

