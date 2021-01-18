using System;
using System.Windows.Input;

namespace ShoppingCart.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? false;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { System.Windows.Input.CommandManager.RequerySuggested += value; }
            remove { System.Windows.Input.CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            System.Windows.Input.CommandManager.InvalidateRequerySuggested();
        }
    }
}
