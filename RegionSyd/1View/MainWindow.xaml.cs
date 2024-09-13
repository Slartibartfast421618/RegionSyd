using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegionSyd._2ViewModel;

namespace RegionSyd._1View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CreateTaskViewModel vm; // HUSK!! Skal ændres til MainVieModel!!!

        public MainWindow()
        {
            InitializeComponent();
            vm = new CreateTaskViewModel();

            DataContext = vm;
            
        }

        private void BtnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateTaskView();
        }
    }
}