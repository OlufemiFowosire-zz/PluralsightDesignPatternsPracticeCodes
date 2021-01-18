using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.State;
using EventBookingProcess.Library.ValueObjects;

namespace EventBookingProcess.Library.Command
{
    public class DatePassedCommand : BookingCommand
    {
        private Booking booking;
        public DatePassedCommand(Booking booking)
        {
            this.booking = booking;
        }

        public bool CanExecute()
        {
            return booking.CurrentStatus == CurrentStateValue.New ||
                   booking.CurrentStatus == CurrentStateValue.Booked;
        }

        public void Execute()
        {
            booking.DatePassed();
        }
    }
}
