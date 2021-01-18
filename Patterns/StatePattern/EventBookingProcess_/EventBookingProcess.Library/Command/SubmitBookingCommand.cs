using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.State;
using EventBookingProcess.Library.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace EventBookingProcess.Library.Command
{
    public class SubmitBookingCommand : BookingAsyncCommand
    {
        private Booking booking;
        public SubmitBookingCommand(Booking booking)
        {
            this.booking = booking;
        }

        public override bool CanExecute()
        {
            return booking.CurrentStatus == CurrentStateValue.New;
        }

        public override Task<CurrentStateValue> ExecuteAsync(CancellationToken token)
        {
            return booking.SubmitBooking(token);
        }
    }
}
