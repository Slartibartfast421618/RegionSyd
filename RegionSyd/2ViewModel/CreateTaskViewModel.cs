using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.MVVM;

namespace RegionSyd._2ViewModel
{
    internal class CreateTaskViewModel : ViewModelBase
    {
        public ObservableCollection<Task> tasks { get; set; } = new ObservableCollection<Task>();
        public Task currentTask;

        public CreateTaskViewModel()
        {
            currentTask = new Task();
        }

        // Relay commands for binding
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());
        
        // Methods that commands execute
        private void AddItem()
        {
            // Technically unnecessary for now
            throw new NotImplementedException();
        }
        private void Save()
        {
            tasks.Add(currentTask);
            currentTask = new Task();
        }
        private bool CanSave()
        {
            // TO-DO: Check if all datafields are filled, and valid
            return true;
        }
    }
}
