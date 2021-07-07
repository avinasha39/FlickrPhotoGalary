using System.Collections.Generic;
using System.ComponentModel;

namespace PhotoSearchProjectInterface
{
    public class Flickrresponse : INotifyPropertyChanged
    {
        private List<PhotoItem> _items;

        /// <summary>
        ///     
        /// </summary>
        public List<PhotoItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
