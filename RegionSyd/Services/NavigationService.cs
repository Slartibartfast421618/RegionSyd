using RegionSyd._1View;

namespace RegionSyd.Services
{
    public class NavigationService : INavigationService
    {
        // NavigationService becomes the propagator for our SharedDataService
        private readonly SharedDataService _sharedDataService;
        private readonly MainWindowView _mainWindowView;

        public NavigationService(SharedDataService sharedDataService, MainWindowView mainWindowView) 
        {
            _sharedDataService = sharedDataService;
            _mainWindowView = mainWindowView;
        }

        // Pages to be opened
        public void OpenCreateAssignmentView()
        {
            _mainWindowView.NavigateTo(new CreateAssignmentView(_sharedDataService));
        }

        public void OpenSearchAssignmentView()
        {
            _mainWindowView.NavigateTo(new SearchAssignmentView(_sharedDataService));
        }

        // Windows to be opened
        // Remember to propagate data as necessary!
        //public void OpenCreateAssignmentView()
        //{
        //    var createAssignmentView = new CreateAssignmentView(_sharedDataService);
        //    createAssignmentView.Show();
            
        //}

        //public void OpenSearchAssignmentView()
        //{
        //    var searchAssignmentView = new SearchAssignmentView(_sharedDataService);
        //    searchAssignmentView.Show();
        //}
    }
}
