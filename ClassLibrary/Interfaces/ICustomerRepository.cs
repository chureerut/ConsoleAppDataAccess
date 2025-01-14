using ClassLibrary.Models;
using System.Collections.Generic;

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
