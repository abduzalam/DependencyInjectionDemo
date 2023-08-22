using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    /// <summary>
    /// DI Notes
    /// Two Classes CustomerService(Higher class) & CustomerDataAccess ( Lower class)
    /// Higher one depends on lower classes means CustomerService classes needs to use the functionality of CustomerDataAccess class
    /// inorder to get data from database. So we can say CustomerService is depends on CustomerDataAccess
    /// </summary>
    public class CustomerService
    {
        private CustomerDataAccess custDA;
        private string connString { get; set; }
        public CustomerService()
        {
            custDA = new CustomerDataAccess(connString);
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return custDA.GetCustomer();
        }
    }

    public class CustomerDataAccess
    {
        public CustomerDataAccess(string connString)
        {
            
        }
        public Customer GetCustomer()
        {
            throw new NotImplementedException();
        }
    }

    public class Customer
    {
      
    }
}
