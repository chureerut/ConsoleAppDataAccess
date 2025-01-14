using System;

namespace ClassLibrary.DataAccess.Core
{
    public class _CustomCore : IDisposable
    {
        public SqlBaseService Db;
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
