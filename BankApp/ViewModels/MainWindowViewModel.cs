using BankApp.Models;
using BankApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public string _title = "BankApp";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _title;            
        }


        public ObservableCollection<Client> ClientsCollection;
        
        public MainWindowViewModel()
        {
            ClientsCollection = DataService.DataLoad(ClientsCollection);
        }



    }
}
