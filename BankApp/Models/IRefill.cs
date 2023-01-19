using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal interface IRefill<in A> where A : class
    {
        void DoRefill(A acc, int sum);
    }
}
