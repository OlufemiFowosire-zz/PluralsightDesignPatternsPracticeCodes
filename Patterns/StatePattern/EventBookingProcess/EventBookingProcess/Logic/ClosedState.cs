namespace EventBookingProcess.Logic
{
    public class ClosedState : BookingState
    {
        private readonly string reasonClosed;
        public ClosedState(string reasonClosed)
        {
            this.reasonClosed = reasonClosed;
        }
        public override void Cancel(BookingContext booking)
        {
            booking.View.ShowError("Invalied action for the state", "Closed booking Error");
        }

        public override void DatePassed(BookingContext booking)
        {

        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {

        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(reasonClosed);
        }
    }
}
