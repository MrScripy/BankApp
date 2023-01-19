using BankApp.Infrastructure.Commands;
using BankApp.Models;
using BankApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public string _title = "BankApp";
        public string Title
        {
            get => _title;
        }
        #region Commands
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        #endregion

        public MainWindowViewModel()
        {
            clientsCollection = DataService.DataLoad<Client>();

        }

        private ObservableCollection<Client> clientsCollection;

        public ObservableCollection<Client> ClientsCollection
        {
            get=> clientsCollection;
            set => Set(ref clientsCollection, value);
        }

        //public MainWindowViewModel()
        //{
        //    ClientsCollection = DataService.DataLoad(ClientsCollection);
        //}



    }
}
