using RegionSyd.Services;
using RegionSyd.Utilities;
using System.Windows.Input;

namespace RegionSyd._2ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand OpenCreateAssignmentViewCommand { get; }
        public ICommand OpenSearchAssignmentViewCommand { get; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OpenCreateAssignmentViewCommand = new RelayCommand(_navigationService.OpenCreateAssignmentView);
            OpenSearchAssignmentViewCommand = new RelayCommand(_navigationService.OpenSearchAssignmentView);
        }
    }
}
