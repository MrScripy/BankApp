using System;


namespace BankApp.Models
{
    class DepositAccount : Account
    {
        private int sumMoney;
        public override int SumMoney { get => sumMoney; set => Set(ref sumMoney, value); }
        public DepositAccount() { }
        public DepositAccount(int sum) : base(sum) { }
    }
}
