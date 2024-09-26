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
            //LoadData();

            // Dummy data for now
            Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY010203040506070809",
                AssignmentType = "Akut",
                AssignmentDescription = "Lortet brænder. Husk at tage Olafs arm med.",
                PatientName = "Olaf",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                AddressFrom = "Vejvej 3, Vejle",
                AddressTo = "Gadegade 9, Gadele",
                DisponentDelegator = 007,
                DisponentCreator = 001,
                RegionID = 2
            }); 
            Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY090807060504030201",
                AssignmentType = "Akut",
                AssignmentDescription = "Lortet Fryser. Husk at tage Olgas storetå med.",
                PatientName = "Olga",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                AddressFrom = "Vejvej 4, Vejle",
                AddressTo = "Gadegade 9, Gadele",
                DisponentDelegator = 007,
                DisponentCreator = 001,
                RegionID = 2
            });
            Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY000000000123465789",
                AssignmentType = "Transport",
                AssignmentDescription = "Hilda skal besøge sin mor.",
                PatientName = "Hilda",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                AddressFrom = "Gadegade 9, Gadele",
                AddressTo = "Ringsted 123, Finstrup",
                DisponentDelegator = 007,
                DisponentCreator = 001,
                RegionID = 2
            });
            Assignments.Add(new Assignment
            {
                RegionalAssignmentID = "SY123456789000000000",
                AssignmentType = "Flyvsk ambutation",
                AssignmentDescription = "With great pleasure, cums great...",
                PatientName = "Rasmus",
                AppointmentTime = new TimeOnly(00, 00),
                AppointmentDate = new DateOnly(2004, 12, 31),
                AddressFrom = "Ringsted 123, Finstrup",
                AddressTo = "Tissted 321, Skagen",
                DisponentDelegator = 007,
                DisponentCreator = 001,
                RegionID = 2
            });
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
            if (!Assignments.Contains(assignment))
            {
                Assignments.Add(assignment);
                _assignmentRepository.Add(assignment);
            }
            //else
            //    _assignmentRepository.Update(assignment);
        }

        public void DeleteAssignemnt(Assignment assignment)
        {
            if (Assignments.Contains(assignment))
            {
                Assignments.Remove(assignment);
                _assignmentRepository.Remove(assignment);
            }
        }

        // Next set of commands
    }
}
