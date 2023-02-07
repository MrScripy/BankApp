using BankApp.Infrastructure.Commands;
using ModelsLibrary.Models;
using ModelsLibrary.Models.Changelog;
using BankApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BankApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Fields
        private ObservableCollection<Client> clientsCollection;
        private ChangelogData changelog;

        private Client selectedClient;

        private List<string> selectedAccount = new List<string>()
        {
            "Депозитный",
            "Текущий"
        };
        #endregion

        #region Properties
        public ObservableCollection<Client> ClientsCollection
        {
            get => clientsCollection;
            set => Set(ref clientsCollection, value);
        }

        public ChangelogData Changelog { get => changelog; }

        public Client SelectedClient { get => selectedClient; set => Set(ref selectedClient, value); }

        public List<string> SelectedAccount { get => selectedAccount; }
        #endregion

        #region Commands
        #region CloseAndSaveCommand
        public ICommand CloseAndSaveApplicationCommand { get; }

        private void OnCloseAndSaveApplicationCommandExecuted(object p)
        {
            DataService.DataSave(clientsCollection);

            DataService.DataSave(changelog.Changelog, "dataChanges.txt");
            Application.Current.Shutdown();
        }

        private bool CanCloseAndSaveApplicationCommandExecute(object p) => true;


        #endregion
        #region AddMoney
        public ICommand AddMoneyCommand { get; }

        private void OnAddMoneyCommandExecuted(object p)
        {
            var values = p as object[];
            if (values.Length == 2)
            {
                var accType = values[0] as string;
                var s = values[1] as string;
                if (int.TryParse(s, out int sum))
                {
                    if (accType == selectedAccount[0])
                    {
                        SelectedClient.DepositAcc.SumMoney += sum;
                        ChangelogData.TrackChanges(SelectedClient.Name, "Депозитный счет", $"пополнение депозитного счета", (SelectedClient.DepositAcc.SumMoney += sum).ToString());
                    }
                    else if (accType == selectedAccount[1])
                    {
                        ChangelogData.TrackChanges(SelectedClient.Name, "Текущий счет", $"пополнение текущего счета", (SelectedClient.CurrentAcc.SumMoney += sum).ToString());
                        SelectedClient.CurrentAcc.SumMoney += sum;
                    }
                }
            }
        }

        private bool CanAddMoneyCommandExecute(object p)
        {
            if (p != null && SelectedClient != null)
            {
                var values = p as object[];
                var accType = values[0] as string;
                var sum = values[1] as string;
                if (values.Length == 2 && !String.IsNullOrEmpty(accType) && !String.IsNullOrEmpty(sum)) 
                    return true;
            }
            return false;
        }
        #endregion
        #region OpenAccount
        public ICommand OpenAccount { get; }

        private void OnOpenAccountExecuted(object p)
        {
            if (p as string == SelectedAccount[0] && SelectedClient.DepositAcc == null) SelectedClient.DepositAcc = new DepositAccount();
            if (p as string == SelectedAccount[1] && SelectedClient.CurrentAcc == null) SelectedClient.CurrentAcc = new CurrentAccount();
        }

        private bool CanOpenAccountExecuted(object p)
        {
            if (p != null && SelectedClient != null)
            {
                if (p as string == selectedAccount[0] && SelectedClient.DepositAcc == null) return true;
                if (p as string == selectedAccount[1] && SelectedClient.CurrentAcc == null) return true;
            }
            return false;
        }

        #endregion
        #region CloseAccount
        public ICommand CloseAccount { get; }

        private void OnCloseAccountExecuted(object p)
        {
            if (p as string == SelectedAccount[0] && SelectedClient.DepositAcc != null) SelectedClient.DepositAcc = null;
            if (p as string == SelectedAccount[1] && SelectedClient.CurrentAcc != null) SelectedClient.CurrentAcc = null;

        }

        private bool CanCloseAccountExecuted(object p)
        {
            if (p != null && SelectedClient != null)
            {
                if (p as string == selectedAccount[0] && SelectedClient.DepositAcc != null) return true;
                if (p as string == selectedAccount[1] && SelectedClient.CurrentAcc != null) return true;
            }
            return false;
        }

        #endregion
        #region TransferMoney
        public ICommand TransferMoneyCommand { get; }

        private void OnTransferMoneyCommandExecuted(object p)
        {
            var values = p as object[];
            if (values.Length == 4)
            {
                var name = values[0] as string;
                var accAddType = values[1] as string;
                var accTakeType = values[2] as string;
                var s = values[3] as string;
                int index = CheckCollection(name);
                if (index != -1 && int.TryParse(s, out int sum))
                {
                    ChangelogData.TrackChanges($"{SelectedClient.Name}\n{name}", $"Перевод денежных средств со счета {SelectedClient.Name} на счет {name}", "", sum.ToString());
                    Transfer(index, accAddType, accTakeType, sum);
                }

            }
        }

        private bool CaTransferMoneyCommandExecute(object p)
        {
            if (p != null && SelectedClient != null)
            {
                var values = p as object[];
                if (values.Length == 4)
                {
                    var name = values[0] as string;
                    var accAddType = values[1] as string;
                    var accTakeType = values[2] as string;
                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(accAddType) && !String.IsNullOrEmpty(accTakeType))
                        return true;
                }
            }
            return false;
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            try
            {
                clientsCollection = DataService.DataLoad<Client>();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"База клиентов пуста!\nИсключение: {ex.Message}", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            changelog = new ChangelogData();
            try
            {
                changelog.Changelog = DataService.DataLoad<Changes>("dataChanges.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Журнал изменений пуст!\nИсключение: {ex.Message}", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            #region Commands
            CloseAndSaveApplicationCommand = new LambdaCommand(OnCloseAndSaveApplicationCommandExecuted, CanCloseAndSaveApplicationCommandExecute);
            AddMoneyCommand = new LambdaCommand(OnAddMoneyCommandExecuted, CanAddMoneyCommandExecute);
            OpenAccount = new LambdaCommand(OnOpenAccountExecuted, CanOpenAccountExecuted);
            CloseAccount = new LambdaCommand(OnCloseAccountExecuted, CanCloseAccountExecuted);
            TransferMoneyCommand = new LambdaCommand(OnTransferMoneyCommandExecuted, CaTransferMoneyCommandExecute);
            #endregion
        }

        #region PrivateMethods
        private int CheckCollection(string name)
        {
            int index = -1;
            for (int i = 0; i < clientsCollection.Count; i++)
            {
                if (clientsCollection[i].Name == name)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private void Transfer(int index, string addAcc, string takeAcc, int sum)
        {
            if (Equals(addAcc, takeAcc))
            {
                if (Equals(addAcc, SelectedAccount[0]))
                {
                    SelectedClient.DepositAcc.SumMoney -= sum;
                    ClientsCollection[index].DepositAcc.SumMoney += sum;
                }
                else if (Equals(addAcc, SelectedAccount[1]))
                {
                    SelectedClient.CurrentAcc.SumMoney -= sum;
                    ClientsCollection[index].CurrentAcc.SumMoney += sum;
                }
            }
            else if (Equals(takeAcc, SelectedAccount[0]))
            {
                SelectedClient.DepositAcc.SumMoney -= sum;
                ClientsCollection[index].CurrentAcc.SumMoney += sum;
            }
            else
            {
                SelectedClient.CurrentAcc.SumMoney -= sum;
                ClientsCollection[index].DepositAcc.SumMoney += sum;
            }
        }

        #endregion              
    }
}
