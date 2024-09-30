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

        private string _searchStreetNameFrom;
        private int _searchStreetNumberFrom;
        private int _searchZipcodeFrom;
        private string _searchStreetNameTo;
        private int _searchStreetNumberTo;
        private int _searchZipcodeTo;

        public string SearchStreetNameFrom
        {
            get { return _searchStreetNameFrom; }
            set { _searchStreetNameFrom = value; }
        }

        public int SearchStreetNumberFrom
        {
            get { return _searchStreetNumberFrom; }
            set { _searchStreetNumberFrom = value; }
        }

        public int SearchZipcodeFrom
        {
            get { return _searchZipcodeFrom; }
            set { _searchZipcodeFrom = value; OnPropertyChanged(); }
        }

        public string SearchStreetNameTo
        {
            get { return _searchStreetNameTo; }
            set { _searchStreetNameTo = value; }
        }

        public int SearchStreetNumberTo
        {
            get { return _searchStreetNumberTo; }
            set { _searchStreetNumberTo = value; }
        }

        public int SearchZipcodeTo
        {
            get { return _searchZipcodeTo; }
            set { _searchZipcodeTo = value; OnPropertyChanged(); }
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
            SearchStreetNameFrom = string.Empty; 
            SearchStreetNumberFrom = 0; 
            SearchZipcodeFrom = 0;
            SearchStreetNameFrom = string.Empty;
            SearchStreetNumberFrom = 0;
            SearchZipcodeTo = 0;
        }

        public void SearchThroughAssignments()
        {
            // Check if a filter is empty, if it is, don't use it. 
            // Filters: SearchZipcodeFrom, SearchZipcodeTo, SearchAssignmentTime
            // Take data from Assignments, overlay to FilteredAssignments

            var tempList = Assignments.ToList().FindAll(x
                => (x.StreetNameFrom?.Contains(SearchStreetNameFrom) == true || SearchStreetNameFrom.IsNullOrEmpty())
                && (x.ZipcodeFrom == SearchZipcodeFrom == true || SearchZipcodeFrom == 0)
                && (x.ZipcodeTo == SearchZipcodeTo == true || SearchZipcodeTo == 0));
            
            // Use .Clear() to retain databinding
            FilteredAssignments.Clear();
            foreach (Assignment assignment in tempList) 
                FilteredAssignments.Add(assignment);
        }
    }
}
