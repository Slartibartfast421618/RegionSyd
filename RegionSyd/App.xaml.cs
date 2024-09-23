using Microsoft.Extensions.Configuration;
using System.Windows;
using System.IO;
using RegionSyd._1View;
using RegionSyd._3Model;
using RegionSyd._2ViewModel;

namespace YourAppNamespace
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
            var repository = new AssignmentRepository(_configuration);
            var mainViewModel = new MainViewModel(repository);

            // Opret MainWindow med den ViewModel
            var mainWindow = new MainWindowView
            {
                DataContext = mainViewModel
            };

            mainWindow.Show();
        }
    }
}