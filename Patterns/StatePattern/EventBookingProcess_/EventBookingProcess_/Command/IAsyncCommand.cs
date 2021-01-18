using System.Threading.Tasks;
using System.Windows.Input;

namespace EventBookingProcess_.Command
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
