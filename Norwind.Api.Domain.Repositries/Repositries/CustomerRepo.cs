using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Norwind.Api.Domain.Entities.Interfaces;
using Norwind.Api.Domain.Repositries.Common;

namespace Norwind.Api.Domain.Repositries.Repositries
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly Connections _connections;
        private readonly InstnwndContext _operationContext;


        public CustomerRepo(IOptions<Connections> connections, InstnwndContext operationContext)
        {
            _operationContext = operationContext;
            _connections = connections.Value;
        }
        public string GetEnviroment()
        {
            return _connections.EnvName;
        }

        
        
        public IEnumerable<Customer> GetCustomer()
        {
            return _operationContext.Customers.ToList();
        }




        public Customer GetCustomerById(string customerId)
        {
            var res = _operationContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            return res;
        }

        
        
        public bool AddCustomer(Customer customer)
        {
            try
            {
                _operationContext.Customers.Add(customer);
                _operationContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

       
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var ec = _operationContext.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                if (ec != null)
                {
                    ec.CompanyName = customer.CompanyName;
                    ec.ContactName = customer.ContactName;
                    ec.ContactTitle = customer.ContactTitle;
                    ec.Address = customer.Address;
                    ec.City = customer.City;
                    ec.Region = customer.Region;
                    ec.PostalCode = customer.PostalCode;    
                    ec.Country = customer.Country;
                    ec.Phone = customer.Phone;
                    ec.Fax = customer.Fax;
                    _operationContext.SaveChanges();
                    return true;
                }
                return false; 
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        
        public bool DeleteCustomer(string customerId)
        {
            try
            {
                var customer = _operationContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                if (customer != null)
                {
                    _operationContext.Customers.Remove(customer);
                    _operationContext.SaveChanges();
                    return true;
                }
                return false; 
            }
            catch (Exception)
            {
                
                return false;
            }
        }
    }
}
