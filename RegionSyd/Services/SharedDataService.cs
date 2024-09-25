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
