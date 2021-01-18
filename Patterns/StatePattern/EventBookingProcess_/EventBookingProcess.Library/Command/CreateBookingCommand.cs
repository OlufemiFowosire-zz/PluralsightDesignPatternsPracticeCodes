using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.State;
using EventBookingProcess.Library.ValueObjects;

namespace EventBookingProcess.Library.Command
{
    public class CreateBookingCommand : BookingCommand
    {
        private Booking booking;
        public CreateBookingCommand(Booking booking)
        {
            this.booking = booking;
        }

        public bool CanExecute()
        {
            return booking.CurrentStatus == CurrentStateValue.No_Booking ||
                   booking.CurrentStatus == CurrentStateValue.Failed ||
                   booking.CurrentStatus == CurrentStateValue.Closed ||
                   booking.CurrentStatus == CurrentStateValue.Booked;
        }

        public void Execute()
        {
            booking.CreateBooking();
        }
    }
}
