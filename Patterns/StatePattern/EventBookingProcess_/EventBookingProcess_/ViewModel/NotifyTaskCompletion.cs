using System.ComponentModel;
using System.Threading.Tasks;

namespace EventBookingProcess_.ViewModel
{
    public sealed class NotifyTaskCompletion<TResult> : INotifyPropertyChanged
    {
        public Task<TResult> Task { get; set; }
        public Task TaskCompletion { get; private set; }
        public TResult Result => (IsSuccessfullyCompleted) ? Task.Result : default(TResult);
        public TaskStatus Status => Task.Status;
        public bool IsCompleted => Task.IsCompleted;
        public bool IsNotCompleted => !IsCompleted;
        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;
        public bool IsNotSuccessfullyCompleted => !IsSuccessfullyCompleted;
        public bool IsCanceled => Task.IsCanceled;
        public bool IsFaulted => Task.IsFaulted;

        public NotifyTaskCompletion(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
                TaskCompletion = WatchTaskAsync(task);

        }

        private async Task WatchTaskAsync(Task<TResult> task)
        {
            try
            {
                await task;
            }
            catch
            {
            }
            var propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;
            propertyChanged(this, new PropertyChangedEventArgs("Status"));
            propertyChanged(this, new PropertyChangedEventArgs("IsCompleted"));
            propertyChanged(this, new PropertyChangedEventArgs("IsNotCompleted"));
            if (task.IsCanceled)
                propertyChanged(this, new PropertyChangedEventArgs("IsCanceled"));
            else if (task.IsFaulted)
            {
                propertyChanged(this, new PropertyChangedEventArgs("IsFaulted"));
            }
            else
            {
                propertyChanged(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                propertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
