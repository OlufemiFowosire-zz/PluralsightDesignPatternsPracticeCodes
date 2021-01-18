using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventBookingProcess_.Command
{
    public abstract class AbstractRelayCommand : ICommand
    {
        IAsyncCommand relayAsyncCommand;
        public abstract event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
