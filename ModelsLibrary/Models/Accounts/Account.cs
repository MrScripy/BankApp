using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ModelsLibrary.Models
{
    abstract public class Account : INotifyPropertyChanged
    {
        public virtual int SumMoney { get; set; }
        public Account()
        {
            SumMoney = 0;
        }
        internal Account(int sum)
        {
            SumMoney = sum;
        }

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
