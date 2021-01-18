using EventBookingProcess_.ViewModel;
using System.Windows.Controls;

namespace EventBookingProcess_
{
    /// <summary>
    /// Interaction logic for StatusPage.xaml
    /// </summary>
    public partial class StatusPage : Page
    {
        public StatusPage(BookingViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
