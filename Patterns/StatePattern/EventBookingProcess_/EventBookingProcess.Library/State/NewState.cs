using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.ValueObjects;
using System;
using System.Threading;

namespace EventBookingProcess.Library.State
{
    public class NewState : BookingState
    {
        private Booking booking;
        public NewState(Booking booking)
        {
            this.booking = booking;
        }
        public void CancelBooking(CancellationTokenSource cts)
        {
            booking.SetState(new ClosedState(booking, "Booking canceled"), CurrentStateValue.Closed);
        }

        public void CreateBooking()
        {
            booking.BookingId = new Random().Next();
        }

        public void DatePassed()
        {
            booking.SetState(new ClosedState(booking, "Expired event!"), CurrentStateValue.Closed);
        }

        public string StatusMessage()
        {
            return "Processing your booking...";
        }

        public void SubmitBooking()
        {
            booking.SetState(new PendingState(), CurrentStateValue.Pending);
        }

    }
}
