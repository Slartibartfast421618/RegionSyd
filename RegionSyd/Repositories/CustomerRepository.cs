using RegionSyd._3Model;

namespace RegionSyd.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private List<Customer> _customers = new List<Customer>();

        public CustomerRepository()
        {
            // Initialize with dummy data
            _customers = new List<Customer>
            {
                new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" },
                new Customer { FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com" },
                new Customer { FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com" },
                new Customer { FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com" }
            };
        }

        // Methods used in commandbindings
        public IEnumerable<Customer> GetAll() => _customers;

        public void Add(Customer entity) => _customers.Add(entity);

        public void Remove(Customer entity) => _customers.Remove(entity);
    }
}
