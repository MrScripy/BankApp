using System;


namespace ModelsLibrary.Models
{
    public class CurrentAccount : Account
    {
        private int sumMoney;
        public override int SumMoney { get => sumMoney; set => Set(ref sumMoney, value); }
        public CurrentAccount() { }
        public CurrentAccount(int sum) : base(sum) { }
    }
}
