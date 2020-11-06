using System;
using System.Collections.Generic;

namespace WebHost
{
    public class DataService : IDataService
    {
        public List<BankAccount> GetData(DateTimeOffset now)
        {
            return new List<BankAccount>()
            {
                new BankAccount
                {
                    AccountId = Guid.NewGuid()
                }
            };
        }
    }
}