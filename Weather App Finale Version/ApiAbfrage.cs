using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{
    class ApiAbfrage
    {

        private HttpClient httpClient;

        public ApiAbfrage(string apiKey)
        {

            this.httpClient = new HttpClient();
        }

        public async Task<string> GetWetterdaten(string stadt)
        {

            string apiKey = "2d6f3e8f5a9deb9b0b4d72581eddb144";
            string url = $"http://api.openweathermap.org/data/2.5/forecast?q={stadt}&lang=de&appid={apiKey}&units=metric";
        

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                //Console.WriteLine($"Fehler bei der API-Abfrage: {ex.Message}");
                return null;
            }
        }
    }
}







