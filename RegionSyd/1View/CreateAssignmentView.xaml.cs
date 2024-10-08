﻿using RegionSyd._2ViewModel;
using RegionSyd.Services;
using System.Windows.Controls;

namespace RegionSyd._1View
{
    /// <summary>
    /// Interaction logic for CreateAssignmentView.xaml
    /// </summary>
    public partial class CreateAssignmentView : Page
    {
        public CreateAssignmentView(SharedDataService sharedDataService)
        {
            InitializeComponent();

            // Set DataContext to the SharedDataService from NavigationService
            DataContext = new CreateAssignmentViewModel(sharedDataService);
        }
    }
}
