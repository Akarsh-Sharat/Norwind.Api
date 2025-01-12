using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norwind.Api.Domain.Entities.Interfaces
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetCustomer();
        Customer GetCustomerById(string customerId);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(string customerId);


    }
}
