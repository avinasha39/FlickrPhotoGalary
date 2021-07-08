using System;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PhotoSearchProjectInterface.Interface;

namespace PhotoSearchProjectInterface
{
    public class FlickrPhotoSearchService : IPhotoSearchService
    {
        IApiClient _client;
        private readonly string _apiEndpoint;

        /// <summary>
        ///     Constructor
        /// </summary>
        public FlickrPhotoSearchService(IApiClient client)
        {
            _client = client;
            _apiEndpoint = "https://www.flickr.com/services/feeds/photos_public.gne?format=json&nojsoncallback=1";         
        }

        public async Task<T> GetPhotosAsync<T>(string queryParamerter)
        {
            string queryUrl = GetQueryUrl(queryParamerter);

            var response = await _client.GetAsync(queryUrl);

            var deserializedProduct = Activator.CreateInstance<T>();
            if (string.IsNullOrEmpty(response))
            {
                return deserializedProduct;
            }

            deserializedProduct = JsonConvert.DeserializeObject<T>(response);
            return deserializedProduct;
        }

        private string GetQueryUrl(string queryParamerter)
        {
            var uriBuilder = new UriBuilder(_apiEndpoint);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["tags"] = queryParamerter;
            uriBuilder.Query = query.ToString();
            var queryUrl = uriBuilder.ToString();
            return queryUrl;
        }
        
    }
}
