using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.ValueObjects;
using System;
using System.Threading;

namespace EventBookingProcess.Library.State
{
    public class BookedState : BookingState
    {
        private Booking booking;
        public BookedState(Booking booking)
        {
            this.booking = booking;
        }
        public void CancelBooking(CancellationTokenSource cts)
        {
            booking.SetState(new ClosedState(booking, "Expect a refund!"), CurrentStateValue.Closed);
        }

        public void CreateBooking()
        {
            booking.BookingId = new Random().Next();
            booking.SetState(new NewState(booking), CurrentStateValue.New);
        }

        public void DatePassed()
        {
            booking.SetState(new ClosedState(booking, "Hope you enjoyed the event"), CurrentStateValue.Closed);
        }

        public void SubmitBooking()
        {
        }

        public string StatusMessage()
        {
            return "Enjoy the event";
        }
    }
}
