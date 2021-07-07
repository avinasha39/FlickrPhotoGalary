using PhotoSearchProjectInterface.Interface;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhotoSearchProjectInterface
{
    class ApiClient : IApiClient
    {
        private HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAsync(string queryUrl)
        {
            string responseobj = "";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(queryUrl);
                if (response.IsSuccessStatusCode)
                {
                    responseobj = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return responseobj;
        }
    }
}
