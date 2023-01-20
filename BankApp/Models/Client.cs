using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal class Client:INotifyPropertyChanged
    {
        #region Fields
        private string name;
        private string phoneNumber;
        private CurrentAccount currentAcc;
        private DepositAccount depositAcc;
        #endregion

        #region Properties
        public string Name { get => name; set => Set(ref name, value); }
        public string PhoneNumber { get => phoneNumber; set => Set(ref phoneNumber, value); }
        public CurrentAccount CurrentAcc { get => currentAcc; set => Set(ref currentAcc, value); }
        public DepositAccount DepositAcc { get => depositAcc; set => Set(ref depositAcc, value); }
        #endregion

        #region Constructors
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
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
