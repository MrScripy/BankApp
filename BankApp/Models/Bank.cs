using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp.Models
{
    class Bank
    {
        public ObservableCollection<Client>? ClientsCollection;

        public Bank()
        {
            ClientsCollection = DataService.DataLoad(ClientsCollection);
        }
                

        public void OpenAcc<T>(T? account) where T : class, new()
        {
            account = new T(); 
        }
        public void CloseAcc<T>(T? account) where T:class, new() 
        {
            account = null;
        }


    }
}
