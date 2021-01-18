using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.ValueObjects;
using System;
using System.Threading;

namespace EventBookingProcess.Library.State
{
    public class ClosedState : BookingState
    {
        private string reason;
        private Booking booking;
        public ClosedState(Booking booking, string reason = "")
        {
            this.booking = booking;
            this.reason = reason;
        }
        public void CancelBooking(CancellationTokenSource cts)
        {
        }

        public void CreateBooking()
        {
            booking.BookingId = new Random().Next();
            booking.SetState(new NewState(booking), CurrentStateValue.New);
        }

        public void DatePassed()
        {
        }

        public void SubmitBooking()
        {
        }

        public string StatusMessage()
        {
            return reason;
        }
    }
}
