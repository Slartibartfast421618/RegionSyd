using RegionSyd._2ViewModel;
using RegionSyd.Services;
using System.Windows.Controls;

namespace RegionSyd._1View
{
    /// <summary>
    /// Interaction logic for SearchAssignmentView.xaml
    /// </summary>
    public partial class SearchAssignmentView : Page
    {
        public SearchAssignmentView(SharedDataService sharedDataService)
        {
            InitializeComponent();

            // Set DataContext to the SharedDataService from NavigationService
            DataContext = new SearchAssignmentViewModel(sharedDataService);
        }

    }
}
