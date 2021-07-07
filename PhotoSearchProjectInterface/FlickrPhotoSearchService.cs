﻿using System;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PhotoSearchProjectInterface.Interface;
using Unity;

namespace PhotoSearchProjectInterface
{
    public class FlickrPhotoSearchService : IPhotoSearchService
    {
        IApiClient _client;
        private readonly string _apiEndpoint;

        /// <summary>
        ///     Constructor
        /// </summary>
        public FlickrPhotoSearchService(IApiClient client, string URL)
        {
            _client = client;
            _apiEndpoint = URL;         
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