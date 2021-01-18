using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.State;
using EventBookingProcess.Library.ValueObjects;
using System.Threading;

namespace EventBookingProcess.Library.Command
{
    public class CancelBookingCommand : BookingCommand
    {
        private Booking booking;
        private CancellationTokenSource cts;
        public CancelBookingCommand(Booking booking, CancellationTokenSource cts = null)
        {
            this.booking = booking;
            this.cts = cts;
        }

        public bool CanExecute()
        {
            return booking.CurrentStatus ==  CurrentStateValue.New ||
                   booking.CurrentStatus == CurrentStateValue.Pending ||
                   booking.CurrentStatus == CurrentStateValue.Booked;
        }

        public void Execute()
        {
            booking.CancelBooking(cts);
        }
    }
}
