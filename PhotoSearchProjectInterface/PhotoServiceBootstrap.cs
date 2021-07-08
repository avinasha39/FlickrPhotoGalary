using Unity;
using PhotoSearchProjectInterface.Interface;

namespace PhotoSearchProjectInterface
{
    public static class PhotoServiceBootstrap
    {
        private static UnityContainer _container;

        static PhotoServiceBootstrap()
        {
            _container = new UnityContainer();

            _container.RegisterType<IApiClient, ApiClient>();
            _container.RegisterType<IPhotoSearchService, FlickrPhotoSearchService>();
        }

        public static IPhotoSearchService GetSearchService<T>()
        {
            if(typeof(T) == typeof(Flickrresponse))
            {
                return _container.Resolve<IPhotoSearchService>();
            }
            return null;
        }
    }
}
