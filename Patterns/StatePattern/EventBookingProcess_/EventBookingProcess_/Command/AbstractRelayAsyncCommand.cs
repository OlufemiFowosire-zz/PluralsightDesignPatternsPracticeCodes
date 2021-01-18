using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventBookingProcess_.Command
{
    public abstract class AbstractRelayAsyncCommand : IAsyncCommand
    {
        public abstract event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
        public abstract Task ExecuteAsync(object parameter);
    }
}
