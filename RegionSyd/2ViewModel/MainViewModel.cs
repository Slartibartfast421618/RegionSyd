using RegionSyd._3Model;

namespace RegionSyd._2ViewModel
{
    internal class MainViewModel
    {
        private readonly IRepository<Assignment> _assignmentRepository;
        
        public MainViewModel(IRepository<Assignment> assignmentRepository)
        {
            
            _assignmentRepository = assignmentRepository;

        }
    }
}
