using BankApp.Infrastructure.Commands;
using BankApp.Models;
using BankApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
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
        #region AddMoney
        public ICommand AddMoneyCommand { get; }

        private void OnAddMoneyCommandExecuted(object p)
        {
            var values = (object[])p;
            var accType = values[0] as string;
            var s = values[1] as string;
            if (int.TryParse(s, out int sum))
            {
                if (accType == "Депозитный") SelectedClient.DepositAcc.SumMoney += sum;
                else if(accType == "Текущий") SelectedClient.CurrentAcc.SumMoney += sum;
            }
        }

        private bool CanAddMoneyCommandExecute(object p)
        {
            if (p != null) return true;
            return false;
        }
        #endregion

        #endregion



        public MainWindowViewModel()
        {
            clientsCollection = DataService.DataLoad<Client>();

            #region Commands
            CloseAndSaveApplicationCommand = new LambdaCommand(OnCloseAndSaveApplicationCommandExecuted, CanCloseAndSaveApplicationCommandExecute);
            AddMoneyCommand = new LambdaCommand(OnAddMoneyCommandExecuted, CanAddMoneyCommandExecute);
            #endregion
        }

    }
}





//new ObservableCollection<Client>();
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));
//clientsCollection.Add(new Client("FFFF", "1233", new CurrentAccount(100), new DepositAccount(500)));