using RegionSyd._2ViewModel;
using RegionSyd.Services;
using System.Windows.Controls;

namespace RegionSyd._1View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView(SharedDataService sharedDataService)
        {
            InitializeComponent();

            // Set DataContext to the SharedDataService from NavigationService
            DataContext = new LoginViewModel(sharedDataService);
        }
    }
}
