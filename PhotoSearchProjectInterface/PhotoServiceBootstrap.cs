using Unity;
using PhotoSearchProjectInterface.Interface;
using Unity.Resolution;

namespace PhotoSearchProjectInterface
{
    public static class PhotoServiceBootstrap
    {
        private static UnityContainer _container;
        private const string flickrUrl = "https://www.flickr.com/services/feeds/photos_public.gne?format=json&nojsoncallback=1";

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
                return _container.Resolve<IPhotoSearchService>(new ParameterOverride("URL", flickrUrl));
            }
            return null;
        }
    }
}
