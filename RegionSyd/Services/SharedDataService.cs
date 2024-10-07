using RegionSyd._3Model;
using RegionSyd.Repositories;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;

namespace RegionSyd.Services
{
    public class SharedDataService
    {
        // Repositories for database handling
        private readonly AssignmentRepository _assignmentRepository;

        // Collections for Views to watch
        public ObservableCollection<Assignment> Assignments { get; private set; }

        public SharedDataService(IConfiguration configuration)
        {
            // Database links
            _assignmentRepository = new AssignmentRepository(configuration);

            // ObservableCollections for holding data and binding to
            Assignments = new ObservableCollection<Assignment>();

            // Load database on launch
            LoadData();

            // Dummy data for now
            /*Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY010203040506070809",
                AssignmentType = "Akut",
                AssignmentDescription = "Lortet brænder. Husk at tage Olafs arm med.",
                PatientName = "Olaf",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                StreetNameFrom = "Vejvej",
                StreetNumberFrom = 3,
                ZipCodeFrom = 4376,
                StreetNameTo = "Vejvej",
                StreetNumberTo = 4,
                ZipCodeTo = 4376,
                DisponentIDDelegator = "SY007",
                DisponentIDCreator = "SY001"
            }); 
            Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY090807060504030201",
                AssignmentType = "Akut",
                AssignmentDescription = "Lortet Fryser. Husk at tage Olgas storetå med.",
                PatientName = "Olga",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                StreetNameFrom = "Vejvej",
                StreetNumberFrom = 4,
                ZipCodeFrom = 4376,
                StreetNameTo = "Vejvej",
                StreetNumberTo = 9,
                ZipCodeTo = 4376,
                DisponentIDDelegator = "SY007",
                DisponentIDCreator = "SY001"
            });
            Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY000000000123465789",
                AssignmentType = "Transport",
                AssignmentDescription = "Hilda skal besøge sin mor.",
                PatientName = "Hilda",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                StreetNameFrom = "Vejvej",
                StreetNumberFrom = 8,
                ZipCodeFrom = 4376,
                StreetNameTo = "Gadegade",
                StreetNumberTo = 25,
                ZipCodeTo = 6734,
                DisponentIDDelegator = "SY007",
                DisponentIDCreator = "SY001"
            });
            Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY123456789000000000",
                AssignmentType = "Flyvsk ambutation",
                AssignmentDescription = "With great pleasure, cums great...",
                PatientName = "Rasmus",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                StreetNameFrom = "Gadevej",
                StreetNumberFrom = 46,
                ZipCodeFrom = 1020,
                StreetNameTo = "Vejgade",
                StreetNumberTo = 64,
                ZipCodeTo = 2010,
                DisponentIDDelegator = "SY007",
                DisponentIDCreator = "SY001"
            }); */
        }

        private void LoadData()
        {
            var assignments = _assignmentRepository.GetAll();

            // Loaders
            foreach (var assignment in assignments ) 
                Assignments.Add(assignment);
        }

        // Chat code, not linked up to anything!
        // Essentially, SharedDataService talks to repositories, repositories talks to external data source

        // Assignment commands
        public void SaveAssignment(Assignment assignment)
        {
            // Check RegionalAssignmentID instead once properly implemented
            if (!Assignments.Contains(assignment)) 
            {
                Assignments.Add(assignment);
                _assignmentRepository.Add(assignment);
            }
            //else
                // Will be used for updating later, when above comment is fixed
            //    _assignmentRepository.Update(assignment);
        }

        //  Not implemented, administration work
        public void DeleteAssignemnt(Assignment assignment)
        {
            if (Assignments.Contains(assignment))
            {
                Assignments.Remove(assignment);
                _assignmentRepository.Remove(assignment);
            }
        }
    }
}
