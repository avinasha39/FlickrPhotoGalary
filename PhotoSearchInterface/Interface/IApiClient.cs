#region

using System.Threading.Tasks;

#endregion

namespace PhotoSearchInterface
{
    /// <summary>
    ///     Interface to use HTTPClient and get response
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        ///     Method to get async response from passed url
        /// </summary>
        Task<string> GetAsync(string queryUrl);
    }
}