using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal class Client
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public CurrentAccount CurrentAcc { get; set; }
        public DepositAccount DepositAcc { get; set; }

        public Client() { }
        public Client(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public Client(string name, string phoneNumber, CurrentAccount currentAcc, DepositAccount depositAcc) : this(name, phoneNumber)
        {
            CurrentAcc = currentAcc;
            DepositAcc = depositAcc;
        }

    }
}
