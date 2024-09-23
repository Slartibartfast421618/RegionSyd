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
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void BtnCreateAssignment_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateAssignmentView();
        }

        private void BtnSearchAssignment_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SearchAssignmentView();
        }
    }
}