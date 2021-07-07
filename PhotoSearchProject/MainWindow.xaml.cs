using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoSearchProjectInterface.Interface;
using PhotoSearchProjectInterface;
using Unity;
using Unity.Injection;

namespace PhotoSearchProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnityContainer _container;
        private IPhotoSearchService _photoSearchService;

        public MainWindow()
        {
            InitializeComponent();
            //var VM = new MainWindowViewModel();
            //this.DataContext = VM;
            _photoSearchService = PhotoServiceBootstrap.GetSearchService<Flickrresponse>();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var flickrobj = await _photoSearchService.GetPhotosAsync<Flickrresponse>(SearchBox.Text);
            CreateGrid(flickrobj);
        }

        private void CreateGrid( Flickrresponse flickrresponse)
        {
            Grid DynamicGrid = new Grid();
            
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;

            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            ColumnDefinition gridCol4 = new ColumnDefinition();
            
            DynamicGrid.ColumnDefinitions.Add(gridCol1);
            DynamicGrid.ColumnDefinitions.Add(gridCol2);
            DynamicGrid.ColumnDefinitions.Add(gridCol3);
            DynamicGrid.ColumnDefinitions.Add(gridCol4);
            RowDefinition gridrow = new RowDefinition();
            DynamicGrid.RowDefinitions.Add(gridrow);

            int r = 0, c = 0;

            for(int i =0;i< flickrresponse.Items.Count; i++)
            {                
                if(i!=0 && i%4 == 0)
                {
                    RowDefinition gridrowtemp = new RowDefinition();
                    DynamicGrid.RowDefinitions.Add(gridrowtemp);
                    r++;
                    c = 0;
                }

                var imagedata = getImageObj(flickrresponse.Items[i]);
                Grid.SetRow(imagedata, r);
                Grid.SetColumn(imagedata, c);
                c++;
                DynamicGrid.Children.Add(imagedata);
            }

            GridContent.Content = DynamicGrid;
        }

        private Border getImageObj(PhotoItem photoitem)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(photoitem.media.m, UriKind.Absolute));
            img.Height = 150;
            img.Width = 200;
            img.ToolTip = photoitem.title;
            Border border = new Border();
            border.Background = new SolidColorBrush(Colors.LightGray);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Gray);
            border.CornerRadius = new CornerRadius(15);
            border.Child = img;

            return border;
        }
    }
}
