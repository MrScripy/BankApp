using BankApp.Models.Changelog;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BankApp.Models
{
    internal class Client : INotifyPropertyChanged
    {
        #region Fields
        private string name;
        private string phoneNumber;
        private CurrentAccount currentAcc;
        private DepositAccount depositAcc;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set
            {
                if (name != null) ChangelogData.TrackChanges(name, "ФИО", name, value);
                Set(ref name, value, name);
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (phoneNumber != null) ChangelogData.TrackChanges(name, "Телефон", phoneNumber, value);
                Set(ref phoneNumber, value, name);
            }
        }
        public CurrentAccount CurrentAcc
        {
            get => currentAcc;
            set
            {
                if (name != null)
                {
                    if (currentAcc == null)
                    {
                        ChangelogData.TrackChanges(name, "Текущий счет", "", "открытие счета");
                    }
                    if (currentAcc != null)
                    {
                        if (value == null) ChangelogData.TrackChanges(name, "Текущий счет", "", "закрытие счета");
                    }
                    Set(ref currentAcc, value, name);
                }
            }
        }
        public DepositAccount DepositAcc
        {
            get => depositAcc;
            set
            {
                if (name != null)
                {
                    if (depositAcc == null)
                    {
                        ChangelogData.TrackChanges(name, "Депозитный счет", "", "открытие счета");
                    }
                    if (depositAcc != null)
                    {
                        if (value == null) ChangelogData.TrackChanges(name, "Депозитный счет", "", "закрытие счета");
                    }
                    Set(ref depositAcc, value, name);
                }
            }
        }
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
        protected virtual bool Set<T>(ref T field, T value, string name, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
