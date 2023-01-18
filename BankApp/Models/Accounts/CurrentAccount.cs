using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    class CurrentAccount : Account
    {        
        public CurrentAccount() { }
        public CurrentAccount(int sum) : base(sum) { }
    }
}
