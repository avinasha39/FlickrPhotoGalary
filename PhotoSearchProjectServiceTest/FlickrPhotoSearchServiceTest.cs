using NUnit.Framework;
using PhotoSearchProjectInterface;
using PhotoSearchProjectInterface.Interface;
using Rhino.Mocks;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;

namespace PhotoSearchProjectServiceTest
{
    /// <summary>
    ///     Test class for FlickrPhotoSearchService
    /// </summary>
    public class FlickrPhotoSearchServiceTest
    {
        private IApiClient _apiClient;
        private UnityContainer _container;

        /// <summary>
        ///     Constructor
        /// </summary>
        public FlickrPhotoSearchServiceTest()
        {
            _container = new UnityContainer();
        }

        /// <summary>
        ///     Setup
        /// </summary>
        [SetUp]
        public void SetUp()
        {            
            _apiClient = MockRepository.Mock<IApiClient>();
            _container.RegisterInstance(_apiClient, new ContainerControlledLifetimeManager());
        }

        /// <summary>
        ///     Test to check response when valid data is recived from API call
        /// </summary>
        [Test]
        public void TestGetPhotosAsync_WhenResponseIsInvalidString()
        {
            //Arrange
            _apiClient.Stub(x => x.GetAsync(Arg<string>.Is.Anything)).Return(Task<string>.FromResult(""));

            //Act
            var flickrPhotoSearchService = _container.Resolve<FlickrPhotoSearchService>();
            var response = flickrPhotoSearchService.GetPhotosAsync<Flickrresponse>("Test");

            //Assert
            Assert.AreEqual(null, response.Result.Items);
        }

        /// <summary>
        ///     Test to check response count when valid data is recived from API call
        /// </summary>
        [Test]
        public void TestGetPhotosAsync_WhenResponseIsValidString()
        {
            //Arrange
            string JsonResponse = "{\"title\": \"Recent Uploads tagged nature\",\"link\":\"https:\\/\\/www.flickr.com\\/photos\\/tags\\/nature\\/\",\"description\": \"\",\"modified\": \"2021-07-07T10:14:29Z\",\"generator\": \"https:\\/\\/www.flickr.com\",\"items\": [{\"title\": \"dsc05215\",\"media\": {\"m\":\"https:\\/\\/live.staticflickr.com\\/65535\\/51296060448_f27cf58729_m.jpg\"},\"date_taken\": \"2021-06-13T14:46:27-08:00\"}]}";
            _apiClient.Stub(x => x.GetAsync(Arg<string>.Is.Anything)).Return(Task<string>.FromResult(JsonResponse));

            //Act
            var flickrPhotoSearchService = _container.Resolve<FlickrPhotoSearchService>();
            var response = flickrPhotoSearchService.GetPhotosAsync<Flickrresponse>("Test");

            //Assert
            Assert.AreEqual(1, response.Result.Items.Count);
        }
    }
}
