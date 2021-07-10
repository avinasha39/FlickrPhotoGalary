#region

using System.Windows;
using PhotoSearchInterface;
using PhotoSearchService;
using Unity;

#endregion

namespace PhotoSearchProject
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            GetContainer();
            var mainWindow = _container.Resolve<MainWindow>();
            var mainWindowViewModel = _container.Resolve<MainWindowViewModel>();

            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }

        private void GetContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<IPhotoServiceBootstrap, PhotoServiceBootstrap>();
        }
    }
}
