using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd._3Model;
using System.Collections.ObjectModel;

namespace RegionSyd._2ViewModel
{
    internal class SearchAssignmentViewModel : ViewModelBase
    {
        private ObservableCollection<Assignment> _assignments;
        public ObservableCollection<Assignment> Assignments
        {
            get { return _assignments; }
            set
            {
                               
            }
        }

        
    }
}
