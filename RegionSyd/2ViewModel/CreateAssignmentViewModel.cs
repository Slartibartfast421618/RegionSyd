using System.Collections.ObjectModel;
using TheMovies.MVVM;
using RegionSyd._3Model;

namespace RegionSyd._2ViewModel
{
    internal class CreateAssignmentViewModel : ViewModelBase
    {
        public ObservableCollection<Assignment> assignments { get; set; } = new ObservableCollection<Assignment>();
        
        public CreateAssignmentViewModel()
        {

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
            // assignments.Add();
           // kommenteret ud for at køre programmet
        }
        private bool CanSave()
        {
            // TO-DO: Check if all datafields are filled, and valid
            return true;
        }
    }
}
