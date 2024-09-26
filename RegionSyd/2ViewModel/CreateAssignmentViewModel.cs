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

        // Properties and backfields
        // TO-DO: Form RegionAssignmentID from RegionID and assignments.Count()
        private string _regionalAssignmentID;
        public string RegionalAssignmentID
        {
            get { return _regionalAssignmentID; }
            set { _regionalAssignmentID = value; OnPropertyChanged(); }
        }

        private string _assignmentType;
        public string AssignmentType
        {
            get { return _assignmentType; }
            set { _assignmentType = value; OnPropertyChanged(); }
        }

        private string _assignmentDescription;
        public string AssignmentDescription
        {
            get { return _assignmentDescription; }
            set { _assignmentDescription = value; OnPropertyChanged(); }
        }

        private string _patientName;
        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; OnPropertyChanged(); }
        }

        private TimeOnly _appointmentTime;
        public TimeOnly AppointmentTime
        {
            get { return _appointmentTime; }
            set { _appointmentTime = value; OnPropertyChanged(); }
        }

        private DateOnly _appointmentDate;
        public DateOnly AppointmentDate
        {
            get { return _appointmentDate; }
            set { _appointmentDate = value; OnPropertyChanged(); }
        }

        private string _addressFrom;
        public string AddressFrom
        {
            get { return _addressFrom; }
            set { _addressFrom = value; OnPropertyChanged(); }
        }

        private string _addressTo;
        public string AddressTo
        {
            get { return _addressTo; }
            set { _addressTo = value; OnPropertyChanged(); }
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
            if (!RegionalAssignmentID.IsNullOrEmpty() && !AssignmentType.IsNullOrEmpty() 
                && !AssignmentDescription.IsNullOrEmpty() && !PatientName.IsNullOrEmpty()
                && AppointmentTime.IsBetween(new TimeOnly(00, 00), new TimeOnly(23, 59)) 
                && AppointmentDate >= DateOnly.FromDateTime(DateTime.Now)
                && !AddressFrom.IsNullOrEmpty() && !AddressTo.IsNullOrEmpty())
            {
                // TO-DO: Automatically assign DisponentCreator and RegionID
                var assignment = new Assignment { 
                    RegionalAssignmentID = this.RegionalAssignmentID, 
                    AssignmentType = this.AssignmentType,
                    AssignmentDescription = this.AssignmentDescription,
                    PatientName = this.PatientName,
                    AppointmentTime = this.AppointmentTime,
                    AppointmentDate = this.AppointmentDate,
                    AddressFrom = this.AddressFrom,
                    AddressTo = this.AddressTo
                };
                _sharedDataService.Assignments.Add(assignment);
            }
        }
    }
}
