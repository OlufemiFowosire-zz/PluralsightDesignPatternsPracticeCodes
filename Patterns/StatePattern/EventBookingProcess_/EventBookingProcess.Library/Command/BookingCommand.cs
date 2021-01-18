namespace EventBookingProcess.Library.Command
{
    public interface BookingCommand
    {
        void Execute();

        bool CanExecute();
    }
}
