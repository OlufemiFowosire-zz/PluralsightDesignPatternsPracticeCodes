using EventBookingProcess.Library.Service;
using EventBookingProcess.Library.State;
using EventBookingProcess.Library.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace EventBookingProcess.Library.Model
{
    public class Booking
    {
        private BookingState currentState;
        private CancellationToken token;
        public int BookingId { get; set; }
        public string Attendee { get; set; }
        public string TicketCount { get; set; }
        public CurrentStateValue CurrentStatus { get; private set; }
        public string StatusMessage { get; private set; }
        public BookingState CurrentState { get => currentState; private set => currentState = value; }

        public Booking()
        {
            CurrentState = new NoBookingState(this);
            CurrentStatus = CurrentStateValue.No_Booking;
            StatusMessage = CurrentState.StatusMessage();
        }
        public void SetState(BookingState state, CurrentStateValue currentStatus)
        {
            CurrentState = state;
            CurrentStatus = currentStatus;
            StatusMessage = state.StatusMessage();
        }
        public void CreateBooking()
        {
            CurrentState.CreateBooking();
        }
        public Task<CurrentStateValue> SubmitBooking(CancellationToken token)
        {
            this.token = token;
            CurrentState.SubmitBooking();
            return StaticFunction<CurrentStateValue>.ProcessBooking(this, ProcessingComplete, token);
        }
        public void CancelBooking(CancellationTokenSource cts)
        {
            CurrentState.CancelBooking(cts);
        }
        public void DatePassed()
        {
            CurrentState.DatePassed();
        }
        public CurrentStateValue ProcessingComplete(Booking booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Success:
                    booking.SetState(new BookedState(booking), CurrentStateValue.Booked);
                    break;
                case ProcessingResult.Fail:
                    booking.SetState(new NoBookingState(booking), CurrentStateValue.Failed);
                    break;
                case ProcessingResult.Cancel:
                    booking.SetState(new ClosedState(booking, "Booking canceled by the customer"), CurrentStateValue.Closed);
                    break;
            }
            return CurrentStatus;
        }
    }
}
