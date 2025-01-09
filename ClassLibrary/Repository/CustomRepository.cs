using ClassLibrary.DataAccess;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Repository
{
    public class CustomRepository : SqlBaseService, ICustomRepository
    {
        public SqlBaseService Db;
        //query sql
        public string GetText()
        {
            return "OKOK";
        }
        public string GetService()
        {
            throw new NotImplementedException();
        }
        public string TestConnectWeb(string en)
        {
            return "Success";
        }

        public List<Customer> GetCustomer(string en)
        {
            //List<Customer> _cus = new List<Customer>()
            if (!string.IsNullOrEmpty(en))
            {
                string sql = @"select * from MyTable";

                var r = Db.MSSQLExecuteScalar<Customer>(sql).ToList();
                return r;
            }
            return null;
        }

    }
}
