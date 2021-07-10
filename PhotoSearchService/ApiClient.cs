#region

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PhotoSearchInterface;

#endregion

namespace PhotoSearchService
{
    /// <summary>
    ///     Class to initialize HTTPClient and get response from the passed URL
    /// </summary>
    internal class ApiClient : IApiClient
    {
        private readonly HttpClient _client;

        /// <summary>
        ///     Constructor
        /// </summary>
        public ApiClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        ///     Method to get response from passed url and return response as JSON string
        /// </summary>
        public async Task<string> GetAsync(string queryUrl)
        {
            var responseObject = "";
            try
            {
                var response = await _client.GetAsync(queryUrl);
                if (response.IsSuccessStatusCode)
                {
                    responseObject = await response.Content.ReadAsStringAsync();
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

            return responseObject;
        }
    }
}