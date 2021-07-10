#region

using System.ComponentModel;
using PhotoSearchInterface;
using Unity;

#endregion

namespace PhotoSearchProject
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private IPhotoSearchService _photoSearchService;
        private Flickrresponse _flickrresponse;

        /// <summary>
        ///     Event to be raised when property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Property to bind search text box
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        ///     Property to show photos
        /// </summary>
        public Flickrresponse flickrresponse
        {
            get => _flickrresponse;
            private set
            {
                _flickrresponse = value;
                OnPropertyChanged("flickrresponse");
            }
        }

        /// <summary>
        ///     Command to bind with button click
        /// </summary>
        public Command GetPhotoCommand { get; private set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        public MainWindowViewModel(IUnityContainer unityContainer)
        {
            _photoSearchService = unityContainer.Resolve<IPhotoServiceBootstrap>().GetSearchService<Flickrresponse>();
            GetPhotoCommand = new Command(OnGetPhotoCommandClicked);
        }

        private async void OnGetPhotoCommandClicked(object obj)
        {
            try
            {
                flickrresponse = await _photoSearchService.GetPhotosAsync<Flickrresponse>(SearchText);

            }
            catch
            {
                //"Error occured please check your internet connection"
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
