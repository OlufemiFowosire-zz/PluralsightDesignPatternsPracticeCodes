using System.Threading;

namespace EventBookingProcess.Library.State
{
    public interface BookingState
    {
        void CreateBooking();
        void SubmitBooking();
        void CancelBooking(CancellationTokenSource cts);
        void DatePassed();
        string StatusMessage();
    }
}
