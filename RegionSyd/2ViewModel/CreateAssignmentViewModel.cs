using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.IdentityModel.Tokens;
using RegionSyd._3Model;
using RegionSyd.Services;
using RegionSyd.Utilities;

namespace RegionSyd._2ViewModel
{
    public class CreateAssignmentViewModel : ViewModelBase
    {
        private readonly SharedDataService _sharedDataService;

        // Workspaces
        // Potentially unnecessary? Check when we have implemented
        public ObservableCollection<Assignment> Assignments => _sharedDataService.Assignments;

        // Backfields
        private string _regionalAssignmentID;
        private string _assignmentType;
        private string _assignmentDescription;
        private string _patientName;
        private TimeOnly _appointmentTime;
        private DateOnly _appointmentDate;
        private string _streetNameFrom;
        private int _streetNumberFrom;
        private int _zipcodeFrom;
        private string _streetNameTo;
        private int _streetNumberTo;
        private int _zipcodeTo;

        // Properties
        // TO-DO: Form RegionAssignmentID from DisponentIDCreator.RegionID and assignments.Count()
        public string RegionalAssignmentID
        {
            get { return _regionalAssignmentID; }
            set { _regionalAssignmentID = value; OnPropertyChanged(); }
        }

        public string AssignmentType
        {
            get { return _assignmentType; }
            set { _assignmentType = value; OnPropertyChanged(); }
        }

        public string AssignmentDescription
        {
            get { return _assignmentDescription; }
            set { _assignmentDescription = value; OnPropertyChanged(); }
        }

        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; OnPropertyChanged(); }
        }

        public TimeOnly AppointmentTime
        {
            get { return _appointmentTime; }
            set { _appointmentTime = value; OnPropertyChanged(); }
        }

        public DateOnly AppointmentDate
        {
            get { return _appointmentDate; }
            set { _appointmentDate = value; OnPropertyChanged(); }
        }

        public string StreetNameFrom
        {
            get { return _streetNameFrom; }
            set { _streetNameFrom = value; }
        }

        public int StreetNumberFrom
        {
            get { return _streetNumberFrom; }
            set { _streetNumberFrom = value; }
        }

        public int ZipCodeFrom
        {
            get { return _zipcodeFrom; }
            set { _zipcodeFrom = value; OnPropertyChanged(); }
        }

        public string StreetNameTo
        {
            get { return _streetNameTo; }
            set { _streetNameTo = value; }
        }

        public int StreetNumberTo
        {
            get { return _streetNumberTo; }
            set { _streetNumberTo = value; }
        }

        public int ZipCodeTo
        {
            get { return _zipcodeTo; }
            set { _zipcodeTo = value; OnPropertyChanged(); }
        }

        // Commands for binding
        public ICommand AddCreateAssignmentCommand { get; }

        // Constructor
        public CreateAssignmentViewModel(SharedDataService sharedDataService)
        {
            _sharedDataService = sharedDataService;
            AddCreateAssignmentCommand = new RelayCommand(AddCreateAssignment);

            AppointmentTime = new TimeOnly(00, 00);
            AppointmentDate = DateOnly.FromDateTime(DateTime.Now);
        }

        // Command functionalities
        private void AddCreateAssignment()
        {
            // Check if everything seems reasonably valid
            // TO-DO: Missing check for RegionalAssignmentID being unique
            // TO-DO: Figure out better logic for checking AddressIDs
            if (!RegionalAssignmentID.IsNullOrEmpty() && !AssignmentType.IsNullOrEmpty() 
                && !AssignmentDescription.IsNullOrEmpty() && !PatientName.IsNullOrEmpty()
                && AppointmentTime.IsBetween(new TimeOnly(00, 00), new TimeOnly(23, 59)) 
                && AppointmentDate >= DateOnly.FromDateTime(DateTime.Now)
                && !StreetNameFrom.IsNullOrEmpty() && StreetNumberFrom > 0 && ZipCodeFrom > 0 
                && !StreetNameTo.IsNullOrEmpty() && StreetNumberTo > 0 && ZipCodeTo > 0)
            {
                // TO-DO: Automatically assign DisponentIDCreator and RegionID
                var assignment = new Assignment { 
                    RegionalAssignmentID = this.RegionalAssignmentID, 
                    AssignmentType = this.AssignmentType,
                    AssignmentDescription = this.AssignmentDescription,
                    PatientName = this.PatientName,
                    AppointmentTime = this.AppointmentTime,
                    AppointmentDate = this.AppointmentDate,
                    StreetNameFrom = this.StreetNameFrom,
                    StreetNumberFrom = this.StreetNumberFrom,
                    ZipCodeFrom = this.ZipCodeFrom,
                    StreetNameTo = this.StreetNameTo,
                    StreetNumberTo = this.StreetNumberTo,
                    ZipCodeTo = this.ZipCodeTo
                };
                _sharedDataService.SaveAssignment(assignment);

            }
        }
    }
}
