using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        void PopulateCustomers();
    }
}
