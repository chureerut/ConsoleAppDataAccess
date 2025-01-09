using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerId);
        List<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void DeleteCustomer(int customerId);
    }
}
