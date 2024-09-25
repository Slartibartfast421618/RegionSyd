using RegionSyd._3Model;
using RegionSyd.Repositories;
using System.Collections.ObjectModel;

namespace RegionSyd.Services
{
    public class SharedDataService
    {
        // Repositories for database connection
        private readonly ItemRepository _itemRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly PurchaseRepository _purchaseRepository;

        // Collections for Views to watch
        public ObservableCollection<Item> Items { get; private set; }
        public ObservableCollection<Customer> Customers { get; private set; }
        public ObservableCollection<Purchase> Purchases { get; private set; }

        public SharedDataService()
        {
            // Database link
            _itemRepository = new ItemRepository();
            _customerRepository = new CustomerRepository();
            _purchaseRepository = new PurchaseRepository();

            Items = new ObservableCollection<Item>();
            Customers = new ObservableCollection<Customer>();
            Purchases = new ObservableCollection<Purchase>();

            LoadData();
        }

        private void LoadData()
        {
            var items = _itemRepository.GetAll();
            var customers = _customerRepository.GetAll();
            // Next line is specific for loading dummy data
            _purchaseRepository.LoadDummy(_itemRepository, _customerRepository);
            var purchases = _purchaseRepository.GetAll();

            // Loaders
            foreach (var item in items ) 
                Items.Add(item);
            foreach (var customer in customers )
                Customers.Add(customer);
            foreach (var purchase in purchases )
                Purchases.Add(purchase);
        }

        // Chat code, not linked up to anything!
        // Essentially, SharedDataService talks to repositories, repositories talks to external data source

        // Item commands
        public void SaveItem(Item item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
                _itemRepository.Add(item);
            }
            //else
            //    _itemRepository.Update(item);
        }

        public void DeleteItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                _itemRepository.Remove(item);
            }
        }

        // Customer commands
        public void SaveCustomer(Customer customer)
        {
            if (!Customers.Contains(customer))
            {
                Customers.Add(customer);
                _customerRepository.Add(customer);
            }
            //else
            //    _itemRepository.Update(item);
        }

        public void DeleteCustomer(Customer customer)
        {
            if (Customers.Contains(customer))
            {
                Customers.Remove(customer);
                _customerRepository.Remove(customer);
            }
        }
    }
}
