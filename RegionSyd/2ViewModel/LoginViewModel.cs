using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RegionSyd._3Model;
using RegionSyd.Services;
using RegionSyd.Utilities;

namespace RegionSyd._2ViewModel
{
    // CLASS NOTES:
    // Retrieve list of Disponents from database
    // Check login inputs against Disponent list
    // Initialize rest of program, with specific Disponent set
    //  - Or initialize program, then use login afterwards
    // ?Drop rest of Disponent list?
    //  - Only need Disponent to set information, not get
    public class LoginViewModel
    {
        private readonly SharedDataService _sharedDataService;

        public string Username{ get; set; }

        // Commands for binding
        public ICommand ProcessLoginCommand { get; }

        public LoginViewModel(SharedDataService sharedDataService) 
        {
            _sharedDataService = sharedDataService;
            ProcessLoginCommand = new RelayCommand(ProcessLogin);
        }

        // Login check vs database
        // Implementation simply checks if the ID exists in database
        // What is security?
        public void ProcessLogin()
        {
            if (_sharedDataService.CheckDisponentID(Username))
                LoginSuccess(Username);
            // Set label to show error
            else
                Username = "";
        }

        private void LoginSuccess(string userLogin)
        {
            // Set disponent and activate other views
            _sharedDataService.ActiveDisponent = new Disponent(userLogin);
        }
    }
}
