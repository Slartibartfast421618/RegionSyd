using RegionSyd._3Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd._2ViewModel
{
    internal class MainViewModel
    {
        //public MainViewModel(TaskRepository taskRepo)
        //{

        //} 

        private readonly IRepository _taskRepository;
        
        public MainViewModel(IRepository taskRepository)
        {
            
            _taskRepository = taskRepository;

        }
    }
}
