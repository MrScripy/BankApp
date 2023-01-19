using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp.Models
{
    class Bank : IRefill<DepositAccount>, ITransfer<DepositAccount>
    {
        
        public void OpenAcc<T>(T? account) where T : class, new()
        {
            account = new T();
        }
        public void CloseAcc<T>(T? account) where T : class, new()
        {
            account = null;
        }

        
        public void DoRefill(DepositAccount acc, int sum)
        {
            IRefill<DepositAccount> transfer = new TranfserClass();
            transfer.DoRefill(acc, sum);
        }

        public void DoTransfer(DepositAccount debitAcc, DepositAccount addAcc, int sum)
        {
            ITransfer<DepositAccount> transfer = new TranfserClass();
            transfer.DoTransfer(debitAcc, addAcc, sum);
        }

    }
}
