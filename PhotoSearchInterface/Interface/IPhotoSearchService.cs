#region

using System.Threading.Tasks;

#endregion

namespace PhotoSearchInterface
{
    /// <summary>
    ///     Interface to get the data for the passed search key
    /// </summary>
    public interface IPhotoSearchService
    {
        /// <summary>
        ///     Method to get photo for passed search string
        /// </summary>
        Task<T> GetPhotosAsync<T>(string value);
    }
}