using System;
using System.Windows.Input;

namespace ShoppingCart.Commands
{
    public class RedoRelayCommand : ICommand
    {
        private readonly Action redo;
        private readonly Func<bool> canExecute;

        public RedoRelayCommand(Action redo, Func<bool> canExecute)
        {
            this.redo = redo;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? false;
        }

        public void Execute(object parameter)
        {
            redo?.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
