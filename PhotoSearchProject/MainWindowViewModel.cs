using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PhotoSearchProjectInterface;
using PhotoSearchProjectInterface.Interface;

namespace PhotoSearchProject
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private IPhotoSearchService _photoSearchService;
        private Flickrresponse _flickrresponse;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchText { get; set; }

        public Command ShowExamAssistCommand { get; private set; }

        public Flickrresponse flickrresponse
        {
            get => _flickrresponse;
            private set
            {
                _flickrresponse = value;
                OnPropertyChanged("flickrresponse");
            }
        }

        public MainWindowViewModel()
        {
            _photoSearchService = PhotoServiceBootstrap.GetSearchService< Flickrresponse>();
            ShowExamAssistCommand = new Command(OnExamAssistOpenClicked);
        }

        private async void OnExamAssistOpenClicked(object obj)
        {
            flickrresponse = await _photoSearchService.GetPhotosAsync<Flickrresponse>(SearchText);
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
