using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.IdentityModel.Tokens;
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
        private ObservableCollection<Assignment> _filteredAssignments;
        public ObservableCollection<Assignment> FilteredAssignments 
        { 
            get {  return _filteredAssignments; }
            set { _filteredAssignments = value; OnPropertyChanged(); }
        }

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
        // Are we sure this is a reasonable search criteria? How should it work?
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

            // Make a new ObsCol from main Assignment, in order to break databind
            // Otherwise, the filtering deletes entries
            FilteredAssignments = new ObservableCollection<Assignment>(Assignments);

            // Making sure strings aren't null to avoid issues, and a lot of checks
            SearchAddressFrom = string.Empty; SearchAddressTo = string.Empty;
        }

        public void SearchThroughAssignments()
        {
            // Check if a filter is empty, if it is, don't use it. 
            // Filters: SearchAddressFrom, SearchAddressTo, SearchAssignmentTime
            // Take data from Assignments, overlay to FilteredAssignments

            var tempList = Assignments.ToList().FindAll(x
                => (x.AddressFrom?.Contains(SearchAddressFrom) == true || SearchAddressFrom.IsNullOrEmpty())
                && (x.AddressTo?.Contains(SearchAddressTo) == true || SearchAddressTo.IsNullOrEmpty()));
            
            // Use .Clear() to retain databinding
            FilteredAssignments.Clear();
            foreach (Assignment assignment in tempList) 
                FilteredAssignments.Add(assignment);
        }
    }
}
