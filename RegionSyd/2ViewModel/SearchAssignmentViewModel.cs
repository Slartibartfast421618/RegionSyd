using System.Collections.ObjectModel;
using System.Windows.Input;
using RegionSyd._3Model;
using RegionSyd.Services;
using RegionSyd.Utilities;

namespace RegionSyd._2ViewModel
{
    public class SearchAssignmentViewModel : ViewModelBase
    {
        private readonly SharedDataService _sharedDataService;

        // Workspaces
        public ObservableCollection<Assignment> Assignments => _sharedDataService.Assignments;
        public List<Assignment> FilteredAssignments { get; set; }

        private Assignment _selectedAssignment;
        public Assignment SelectedAssignment
        {
            get { return _selectedAssignment; }
            set { _selectedAssignment = value; OnPropertyChanged(); }
        }

        private string _searchAddressFrom;
        public string SearchAddressFrom
        {
            get { return _searchAddressFrom; }
            set { _searchAddressFrom = value; OnPropertyChanged(); }
        }

        private string _searchAddressTo;
        public string SearchAddressTo
        {
            get { return _searchAddressTo; }
            set { _searchAddressTo = value; OnPropertyChanged(); }
        }

        private TimeOnly _searchAssignmentTime;
        public TimeOnly SearchAssignmentTime
        {
            get { return _searchAssignmentTime; }
            set { _searchAssignmentTime = value; OnPropertyChanged(); }
        }

        // Commands for binding
        public ICommand SearchThroughAssignmentsCommand { get; }

        // Constructor
        public SearchAssignmentViewModel(SharedDataService sharedDataService)
        {
            _sharedDataService = sharedDataService;
            SearchThroughAssignmentsCommand = new RelayCommand(SearchThroughAssignments);

            FilteredAssignments = Assignments.ToList();
        }

        public void SearchThroughAssignments()
        {

        }
    }
}
