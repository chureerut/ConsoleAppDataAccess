using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Interfaces
{
    public interface ICustomRepository
    {
        string GetText();
        string GetService();
        string TestConnectWeb(string en);
        List<Customer> GetCustomer(string en);
    }
}
