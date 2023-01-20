using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp.Models
{
    class Bank : ITransfer<DepositAccount>
    {
        public void DoTransfer(DepositAccount debitAcc, DepositAccount addAcc, int sum)
        {
            throw new NotImplementedException();
        }
    }
}
