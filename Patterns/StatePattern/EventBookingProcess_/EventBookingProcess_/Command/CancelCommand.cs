using System;
using System.Threading;
using System.Windows.Input;

namespace EventBookingProcess_.Command
{
    public class CancelCommand : ICommand
    {
        private bool commandExecuting;
        private readonly Action<CancellationTokenSource> execute;
        private readonly Func<CancellationTokenSource, bool, bool> canExecute;
        private CancellationTokenSource cts = new CancellationTokenSource();
        public CancelCommand(Action<CancellationTokenSource> execute, Func<CancellationTokenSource, bool, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public CancellationToken Token => cts.Token;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return canExecute?.Invoke(cts, commandExecuting) ?? false;
        }

        void ICommand.Execute(object parameter)
        {
            execute?.Invoke(cts);
            RaiseCanExecuteChanged();
        }
        public void NotifyTaskStarting()
        {
            commandExecuting = true;
            if (!cts.IsCancellationRequested)
                return;
            cts = new CancellationTokenSource();
            RaiseCanExecuteChanged();
        }
        public void NotifyTaskEnding()
        {
            commandExecuting = false;
            RaiseCanExecuteChanged();
        }
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
