//using System;
//using PhotoSearchProjectInterface;
//using PhotoSearchProjectInterface.Interface;

//namespace PhotoSearchProject
//{
//    class MainWindowViewModel : INotifyPr
//    {
//        private IPhotoSearchService _photoSearchService;

//        public string SearchText { get; set; }

//        public Command ShowExamAssistCommand { get; private set; }

//        public MainWindowViewModel()
//        {
//            _photoSearchService = PhotoServiceBootstrap.GetSearchService<Flickrresponse>();
//            //var searchService = PhotoServiceBootstrap.GetSearchService<Flickrresponse>();
//            ShowExamAssistCommand = new Command(OnExamAssistOpenClicked);
//        }

//        private void OnExamAssistOpenClicked(object obj)
//        {
//            var flickrobj = _photoSearchService.GetPhotosAsync<Flickrresponse>(SearchText);
            
//        }
//    }
//}
