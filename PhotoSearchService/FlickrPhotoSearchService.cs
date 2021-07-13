#region

using System;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PhotoSearchInterface;

#endregion

namespace PhotoSearchService
{
    /// <summary>
    ///     Class to get photo from Flickr API based on topic passed
    /// </summary>
    public class FlickrPhotoSearchService : IPhotoSearchService
    {
        private readonly string _apiEndpoint;
        private readonly IApiClient _client;

        /// <summary>
        ///     Constructor
        /// </summary>
        public FlickrPhotoSearchService(IApiClient client)
        {
            _client = client;
            _apiEndpoint = "https://www.flickr.com/services/feeds/photos_public.gne?format=json&nojsoncallback=1";
        }

        /// <summary>
        ///     Get Photos based on search text passed
        /// </summary>
        public async Task<T> GetPhotosAsync<T>(string queryParamerter)
        {
            var queryUrl = GetQueryUrl(queryParamerter);

            var response = await _client.GetAsync(queryUrl);

            var deserializedProduct = Activator.CreateInstance<T>();
            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Response is null");
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