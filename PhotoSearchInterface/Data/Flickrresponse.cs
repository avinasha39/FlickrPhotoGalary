#region

using System.Collections.Generic;
using System.ComponentModel;

#endregion

namespace PhotoSearchInterface
{
    /// <summary>
    ///     Flickresponse object to contain List of PhotoItem
    /// </summary>
    public class Flickrresponse : INotifyPropertyChanged
    {
        private List<PhotoItem> _items;

        /// <summary>
        ///     List of Items
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

        /// <summary>
        ///     Event to be raised when property changes
        /// </summary>
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