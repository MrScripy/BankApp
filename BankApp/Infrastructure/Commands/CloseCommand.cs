using BankApp.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp.Infrastructure.Commands
{
    internal class CloseCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => Application.Current.Shutdown();
    }
}
