using System;
using System.Collections.Generic;

namespace WebHost
{
    public interface IDataService
    {
        public List<BankAccount> GetData(DateTimeOffset now);
    }
}