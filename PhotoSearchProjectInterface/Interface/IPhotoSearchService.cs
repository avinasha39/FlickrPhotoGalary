using System.Threading.Tasks;

namespace PhotoSearchProjectInterface.Interface
{
    public interface IPhotoSearchService
    {
        /// <summary>
        ///     Method to get by on topic
        /// </summary>
        /// <param name="key"></param>
        Task<T> GetPhotosAsync<T>(string value);
    }
}
