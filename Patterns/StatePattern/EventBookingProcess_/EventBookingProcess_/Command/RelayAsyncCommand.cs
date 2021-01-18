using EventBookingProcess_.ViewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventBookingProcess_.Command
{
    public class RelayAsyncCommand<TResult> : IAsyncCommand, INotifyPropertyChanged
    {
        private readonly Func<CancellationToken, Task<TResult>> command;
        private NotifyTaskCompletion<TResult> execution;
        private readonly Func<bool> canExecute;
        private CancelCommand cancelCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NotifyTaskCompletion<TResult> Execution
        {
            get => execution;
            private set
            {
                execution = value;
                OnPropertyChanged(nameof(execution));
            }
        }

        public ICommand CancelCommand => cancelCommand;

        public RelayAsyncCommand(Func<CancellationToken, Task<TResult>> command, CancelCommand cancelCommand, Func<bool> canExecute)
        {
            this.command = command;
            this.canExecute = canExecute;
            this.cancelCommand = cancelCommand;
        }

        public bool CanExecute(object parameter)
        {
            //return Execution == null || Execution.IsCompleted;
            return canExecute?.Invoke() ?? false;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter).ConfigureAwait(false);
        }

        public async Task ExecuteAsync(object parameter)
        {
            cancelCommand.NotifyTaskStarting();
            Execution = new NotifyTaskCompletion<TResult>(command(cancelCommand.Token));
            await Execution.TaskCompletion;
            cancelCommand.NotifyTaskEnding();
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
        //public void Dispose()
        //{
        //    if (Execution == null)
        //        return;
        //    if (Execution.IsSuccessfullyCompleted)
        //        Execution = null;
        //}
    }
}
