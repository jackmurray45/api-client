using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API_Client
{
    public static class HttpClientHelper
    {
        /// <summary>
        /// HttpClient object used for making API requests
        /// </summary>
        public static HttpClient client { get; set; }

        /// <summary>
        /// Initializes HttpClient class by defining the URI and adds application/json to the HTTP requests
        /// </summary>
        /// Initialize
        public static void Initialize()
        {
            client = new HttpClient();
            //Clear default request header and specify json requests in the header
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        /// <summary>
        /// Takes path of URL and returns JSON from URL as a dynamic type
        /// </summary>
        /// <param name="Name">Path for API</param>
        /// <returns></returns>
        public static async Task<dynamic>  CallApi(string Name)
        {
            Console.WriteLine("Getting {0} from API...", Name);
            using (HttpResponseMessage response = await client.GetAsync(Name))
            { 
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("{0} retrieved from API.", Name);
                    return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
