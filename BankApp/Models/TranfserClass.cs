using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankApp.Models
{
    internal class TranfserClass : ITransfer<DepositAccount>
    {
        public void DoRefill(DepositAccount acc, int sum)
        {
            if(sum>0) acc.SumMoney += sum;
        }

        public void DoTransfer(DepositAccount debitAcc, DepositAccount addAcc, int sum)
        {
            if (sum > debitAcc.SumMoney)
            {
                debitAcc.SumMoney -= sum;
                addAcc.SumMoney += sum;
            }
        }
        
    }
}
