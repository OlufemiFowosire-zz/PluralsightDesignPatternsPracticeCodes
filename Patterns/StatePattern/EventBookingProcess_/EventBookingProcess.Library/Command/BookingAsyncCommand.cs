using EventBookingProcess.Library.State;
using EventBookingProcess.Library.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace EventBookingProcess.Library.Command
{
    public abstract class BookingAsyncCommand : BookingCommand
    {
        public abstract Task<CurrentStateValue> ExecuteAsync(CancellationToken token);

        void BookingCommand.Execute()
        {
        }

        public abstract bool CanExecute();
    }
}
