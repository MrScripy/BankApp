using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    abstract internal class Account
    {
        internal virtual int SumMoney { get; set; }
        internal Account()
        {
            SumMoney = 0;
        }

        internal Account(int sum)
        {
            SumMoney= sum;
        }

    }
}
