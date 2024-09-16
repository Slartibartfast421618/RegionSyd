using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.MVVM;

namespace RegionSyd._2ViewModel
{
    internal class CreateTaskViewModel : ViewModelBase
    {



        // Relay commands for binding
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());
        
        // Methods that commands execute
        private void AddItem()
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            throw new NotImplementedException();
        }

        private bool CanSave()
        {
            return true;
        }
    }
}
