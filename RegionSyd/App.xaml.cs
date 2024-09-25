using Microsoft.Extensions.Configuration;
using System.Windows;
using System.IO;
using RegionSyd._1View;
using RegionSyd._3Model;
using RegionSyd._2ViewModel;
using RegionSyd.Services;

namespace RegionSyd
{
    public partial class App : Application
    {
        private IConfiguration _configuration;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Indlæs konfiguration fra appsettings.json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Opret dependencies manuelt
            //var repository = new AssignmentRepository(_configuration);
            //var mainViewModel = new MainViewModel(repository);

            MainWindowView mainWindow = new MainWindowView();

            // Services used in ViewModels
            // 1. Class to hold data
            SharedDataService sharedDataService = new(_configuration);
            // 2. Class for navigation, conviniently handling data holder
            NavigationService navigationService = new(sharedDataService, mainWindow);

            //var mainWindow = new MainWindowView
            //{
            //    // MainWindow is the navigation screen
            //    DataContext = new MainViewModel(navigationService)
            //};

            MainViewModel mainVM = new MainViewModel(navigationService);
            mainWindow.DataContext = mainVM;

            // Launching MainWindow this way means we remove it from App.xaml's StartupUri
            mainWindow.Show();
        }
    }
}