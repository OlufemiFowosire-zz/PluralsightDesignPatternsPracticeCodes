using EventBookingProcess.Library.Model;
using EventBookingProcess_.ViewModel;
using System.Windows;

namespace EventBookingProcess_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EntryPage entryPage;
        private StatusPage statusPage;
        private BookingViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new BookingViewModel(new Booking());
            DataContext = viewModel;

            entryPage = new EntryPage(viewModel);
            statusPage = new StatusPage(viewModel);
            Main.Content = statusPage;

        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = entryPage;
            this.grdDetails.Visibility = Visibility.Visible;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = statusPage;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = statusPage;
        }

        private void btnDatePassed_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = statusPage;
        }
    }
}
