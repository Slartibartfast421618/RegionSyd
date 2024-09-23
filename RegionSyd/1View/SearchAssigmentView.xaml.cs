using RegionSyd._2ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegionSyd._1View
{
    /// <summary>
    /// Interaction logic for SearchAssignmentView.xaml
    /// </summary>
    public partial class SearchAssignmentView : Page
    {
        public SearchAssignmentView()
        {
            InitializeComponent();
            DataContext = new SearchAssignmentViewModel();
        }

    }
}
