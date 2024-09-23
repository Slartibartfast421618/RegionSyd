using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RegionSyd._2ViewModel
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        // INotifyPropertyChanged handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
