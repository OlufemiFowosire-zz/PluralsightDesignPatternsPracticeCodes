using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.ValueObjects;
using System;
using System.Threading;

namespace EventBookingProcess.Library.State
{
    public class NoBookingState : BookingState
    {
        private Booking booking;
        public NoBookingState(Booking booking)
        {
            this.booking = booking;
        }
        public void CancelBooking(CancellationTokenSource cts)
        {
        }

        public void DatePassed()
        {
        }

        public void CreateBooking()
        {
            if(booking.CurrentStatus != CurrentStateValue.Failed)
                booking.BookingId = new Random().Next();
            booking.SetState(new NewState(booking), CurrentStateValue.New);
        }

        public void SubmitBooking()
        {
        }

        public string StatusMessage()
        {
            return "Register for the event...";
        }
    }
}
