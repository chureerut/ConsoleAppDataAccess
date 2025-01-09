using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
