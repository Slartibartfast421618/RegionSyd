using System.Collections.ObjectModel;
using System.Windows.Input;
using RegionSyd._3Model;

namespace RegionSyd._2ViewModel
{
    internal class SearchAssignmentViewModel : ViewModelBase
    {
        private ObservableCollection<Assignment> _assignments;
        public ObservableCollection<Assignment> Assignments
        {
            get => _assignments;
            set
            {
                _assignments = value;
                OnPropertyChanged(nameof(Assignments));
            }
        }

        public ICommand SearchCommand { get; }

        public SearchAssignmentViewModel()
        {
            Assignments = new ObservableCollection<Assignment>();
            SearchCommand = new RelayCommand(SearchAssignments);
        }

        
        private void SearchAssignments(object parameter)
        {
            
            Assignments.Clear();

            // Add dummy data
            Assignments.Add(new Assignment("A001", "Transport", "Patient Transport", "John Doe", TimeOnly.Parse("14:30"), DateOnly.Parse("2024-09-23"), "Street A", "Street B", 1, 1, 1));
            Assignments.Add(new Assignment("A002", "Medical", "Checkup", "Jane Smith", TimeOnly.Parse("15:00"), DateOnly.Parse("2024-09-23"), "Street C", "Street D", 1, 2, 2));
        }
    }
}
