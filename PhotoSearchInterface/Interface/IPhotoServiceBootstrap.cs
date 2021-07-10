namespace PhotoSearchInterface
{
    /// <summary>
    ///     Interface to get instance of Bootstrap
    /// </summary>
    public interface IPhotoServiceBootstrap
    {
        /// <summary>
        ///     Method to return instance of IPhotoSearchService based on passed type
        /// </summary>
        IPhotoSearchService GetSearchService<T>();
    }
}