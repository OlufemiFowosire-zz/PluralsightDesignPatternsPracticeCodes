using EventBookingProcess.Library.Model;
using System.Threading;

namespace EventBookingProcess.Library.State
{
    public class PendingState : BookingState
    {
        public void CancelBooking(CancellationTokenSource cts)
        {
            cts.Cancel();
        }

        public void CreateBooking()
        {
        }

        public void DatePassed()
        {
        }

        public void SubmitBooking()
        {
        }
        public string StatusMessage()
        {
            return "Processing your booking...";
        }
    }
}
