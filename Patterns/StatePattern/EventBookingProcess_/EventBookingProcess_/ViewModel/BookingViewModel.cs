using EventBookingProcess.Library.Command;
using EventBookingProcess.Library.Model;
using EventBookingProcess.Library.Service;
using EventBookingProcess.Library.ValueObjects;
using EventBookingProcess_.Command;
using System.Windows.Input;

namespace EventBookingProcess_.ViewModel
{
    public class BookingViewModel : ViewModelBase
    {
        private readonly CommandController controller = CommandController.Instance;
        public ICommand CreateBookingCommand { get; private set; }
        public CancelCommand CancelBookingCommand { get; private set; }
        public RelayAsyncCommand<CurrentStateValue> SubmitBookingCommand { get; private set; }
        public ICommand DatePassedCommand { get; private set; }
        public Booking Booking { get; private set; }

        public BookingViewModel(Booking booking)
        {
            Booking = booking;
            var createBookingCommand = new CreateBookingCommand(Booking);
            var cancelBookingCommand = new CancelBookingCommand(Booking);
            var submitBookingCommand = new SubmitBookingCommand(Booking);
            var datePassedCommand = new DatePassedCommand(Booking);

            CreateBookingCommand = new RelayCommand(
                execute: () =>
                {
                    controller.Invoke(createBookingCommand);
                    Refresh();
                },
                canExecute: () => createBookingCommand.CanExecute()
            );
            CancelBookingCommand = new CancelCommand(
                execute: (cts) =>
                {
                    cancelBookingCommand = new CancelBookingCommand(Booking, cts);
                    controller.Invoke(cancelBookingCommand);
                    Refresh();
                },
                canExecute: (cts, commandExecuting) => (commandExecuting && !cts.IsCancellationRequested) || cancelBookingCommand.CanExecute()
            );
            SubmitBookingCommand = new RelayAsyncCommand<CurrentStateValue>(
                async (token) =>
                {
                    var status = await controller.Invoke(submitBookingCommand, token);
                    Refresh();
                    return status;
                },
                CancelBookingCommand,
                canExecute: () => submitBookingCommand.CanExecute()
            );
            DatePassedCommand = new RelayCommand(
                () =>
                {
                    controller.Invoke(datePassedCommand);
                    Refresh();
                },
                () => datePassedCommand.CanExecute()
            );
            Refresh();
        }
        public void Refresh()
        {
            OnPropertyChanged(nameof(Booking));
        }
    }
}