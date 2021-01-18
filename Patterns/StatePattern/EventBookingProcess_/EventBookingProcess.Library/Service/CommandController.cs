using EventBookingProcess.Library.Command;
using EventBookingProcess.Library.State;
using EventBookingProcess.Library.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace EventBookingProcess.Library.Service
{
    public sealed class CommandController
    {
        private readonly static CommandController instance = new CommandController();
        public static CommandController Instance => instance;
        private CommandController()
        {
        }
        public void Invoke(BookingCommand command)
        {
            command.Execute();
        }
        public Task<CurrentStateValue> Invoke(BookingAsyncCommand command, CancellationToken token)
        {
            return command.ExecuteAsync(token);
        }
    }
}
