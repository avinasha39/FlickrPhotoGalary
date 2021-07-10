#region

using PhotoSearchInterface;
using Unity;

#endregion

namespace PhotoSearchService
{
    /// <summary>
    ///     Class to bootstrap
    /// </summary>
    public class PhotoServiceBootstrap : IPhotoServiceBootstrap
    {
        private readonly IUnityContainer _container;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="container"></param>
        public PhotoServiceBootstrap(IUnityContainer container)
        {
            _container = container;

            _container.RegisterType<IApiClient, ApiClient>();
            _container.RegisterType<IPhotoSearchService, FlickrPhotoSearchService>();
        }

        /// <summary>
        ///     Method to get IPhotoSearchService instance based on type of response passed
        /// </summary>
        public IPhotoSearchService GetSearchService<T>()
        {
            if (typeof(T) == typeof(Flickrresponse))
            {
                return _container.Resolve<IPhotoSearchService>();
            }

            return null;
        }
    }
}