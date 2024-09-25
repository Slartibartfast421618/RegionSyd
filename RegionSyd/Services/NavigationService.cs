using RegionSyd._1View;

namespace RegionSyd.Services
{
    public class NavigationService : INavigationService
    {
        // NavigationService becomes the propagator for our SharedDataService
        private readonly SharedDataService _sharedDataService;

        public NavigationService(SharedDataService sharedDataService) 
        {
            _sharedDataService = sharedDataService;
        }

        // Windows to be opened
        // Remember to propagate data as necessary!
        public void OpenItemWindow()
        {
            var itemWindow = new ItemWindow(_sharedDataService);
            itemWindow.Show();
        }

        public void OpenCustomerWindow()
        {
            var customerWindow = new CustomerWindow(_sharedDataService);
            customerWindow.Show();
        }

        public void OpenPurchaseWindow()
        {
            var purchaseWindow = new PurchaseWindow(_sharedDataService);
            purchaseWindow.Show();
        }
    }
}
