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

        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchText { get; set; }

        public Command GetPhotoCommand { get; private set; }

        public Flickrresponse flickrresponse
        {
            get => _flickrresponse;
            private set
            {
                _flickrresponse = value;
                OnPropertyChanged("flickrresponse");
            }
        }

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
