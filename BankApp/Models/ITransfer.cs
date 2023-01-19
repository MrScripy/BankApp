using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal interface ITransfer<in A> where A : class
    {
        void DoTransfer(A debitAcc, A addAcc, int sum);
    }
}
