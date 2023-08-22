using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class CustomerService : ICustomerService

    {
        private List<Customer> customers;
     
        public Customer GetCustomerById(int id)
        {

            return customers.FirstOrDefault(c => c.Id == id);
        }
        public void PopulateCustomers()
        {
            customers = new List<Customer>
            {
                new Customer { Id=1, Name = "Abdul Salam"},
                new Customer { Id=2, Name = "Dileep D"},
                new Customer { Id=3, Name = "Jees P"},
                new Customer { Id=4, Name = "Anoop Aug"},
                new Customer { Id=5, Name = "Arun"},
            };
        }
    }
}
