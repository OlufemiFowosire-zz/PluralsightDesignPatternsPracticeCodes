using System;
using System.Windows.Input;

namespace ShoppingCart.Commands
{
    public class UndoRelayCommand : ICommand
    {
        private readonly Action undo;
        private readonly Func<bool> canExecute;

        public UndoRelayCommand(Action undo, Func<bool> canExecute)
        {
            this.undo = undo;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? false;
        }

        public void Execute(object parameter)
        {
            undo?.Invoke();
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
