using System.ComponentModel;
using System.Collections.Generic;

namespace PhotoSearchProjectInterface
{
    public class Flickrresponse : INotifyPropertyChanged
    {
        private List<PhotoItem> _items;

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
