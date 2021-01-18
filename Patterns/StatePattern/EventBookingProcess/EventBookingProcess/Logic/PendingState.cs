using System.Threading;

namespace EventBookingProcess.Logic
{
    public class PendingState : BookingState
    {
        private CancellationTokenSource cancelToken;
        public override void Cancel(BookingContext booking)
        {
            cancelToken.Cancel();
        }

        public override void DatePassed(BookingContext booking)
        {

        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {

        }

        public override void EnterState(BookingContext booking)
        {
            cancelToken = new CancellationTokenSource();

            booking.ShowState("Pending");
            booking.View.ShowStatusPage("Processing booking");
            StaticFunctions.ProcessBooking(booking, ProcessingComplete, cancelToken);
        }
        public void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.TransitionToState(new NewState());
                    booking.View.ShowProcessingError();
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Canceled"));

                    break;
                default:
                    break;
            }
        }
    }
}
