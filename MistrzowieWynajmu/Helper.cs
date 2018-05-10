using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MistrzowieWynajmu
{
    public class PropertyAPI
    {
        private string _apiBaseURL = "http://localhost:60883";
        public HttpClient InitalizeClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_apiBaseURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
    public class Helper
    {


    }
}
