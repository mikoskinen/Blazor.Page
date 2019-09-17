using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Page.Samples.Basic.Pages
{
    public class CounterPageModel : PageModelBase
    {
        private readonly CustomerService _customerService;
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public CounterPageModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public override async Task OnInitializedAsync()
        {
            await LoadCustomers();
        }

        private async Task LoadCustomers()
        {
            var custs = await _customerService.GetCustomers();

            Customers.Clear();
            Customers.AddRange(custs);
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }

    public class CustomerService
    {
        public Task<List<Customer>> GetCustomers()
        {
            var result = new List<Customer>();
            for(var i = 0; i < 10; i++)
            {
                var cust = new Customer() { FirstName = $"Firstname {i + 1}", LastName = $"Lastname {i + 1}" };
                result.Add(cust);
            }

            return Task.FromResult(result);
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
