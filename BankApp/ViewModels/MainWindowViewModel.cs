using BankApp.Infrastructure.Commands;
using BankApp.Models;
using BankApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private ObservableCollection<Client> clientsCollection;

        private Client selectedClient;

        private List<string> selectedAccount = new List<string>()
        {
            "Депозитный",
            "Текущий"
        };


        #region Properties
        public ObservableCollection<Client> ClientsCollection
        {
            get => clientsCollection;
            set => Set(ref clientsCollection, value);
        }
        public Client SelectedClient
        {
            get => selectedClient;
            set => Set(ref selectedClient, value);
        }

        public List<string> SelectedAccount
        {
            get => selectedAccount;
        }
        #endregion

        #region Commands
        #region CloseCommand
        public ICommand CloseAndSaveApplicationCommand { get; }

        private void OnCloseAndSaveApplicationCommandExecuted(object p)
        {
            DataService.DataSave(clientsCollection);
            Application.Current.Shutdown();
        }

        private bool CanCloseAndSaveApplicationCommandExecute(object p) => true;


        #endregion
        public ICommand AddMoneyCommand { get; }

        private void OnAddMoneyCommandCommandExecuted(object p)
        {
            if (SelectedClient != null)
                SelectedClient.CurrentAcc.SumMoney += 100;
        }

        private bool CanAddMoneyCommandCommandExecute(object p) => true;
        #endregion



        public MainWindowViewModel()
        {
            clientsCollection = DataService.DataLoad<Client>();

            #region Commands
            CloseAndSaveApplicationCommand = new LambdaCommand(OnCloseAndSaveApplicationCommandExecuted, CanCloseAndSaveApplicationCommandExecute);
            AddMoneyCommand = new LambdaCommand(OnAddMoneyCommandCommandExecuted, CanAddMoneyCommandCommandExecute);
            #endregion
        }

    }
}





//new ObservableCollection<Client>();
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));