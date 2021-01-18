using EventBookingProcess.Logic;
using System.Windows;

namespace EventBookingProcess.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EntryPage entryPage = new EntryPage();
        private readonly StatusPage statusPage = new StatusPage();

        private BookingContext booking;
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = statusPage;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            booking = new BookingContext(this);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string attendee = entryPage.txtAttendee.Text;
            int.TryParse(entryPage.txtTicketCount.Text, out int ticketCount);
            if (booking != null)
            {
                booking.SubmitDetails(attendee, ticketCount);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (booking != null)
            {
                booking.Cancel();
            }
        }

        private void btnDatePassed_Click(object sender, RoutedEventArgs e)
        {
            if (booking != null)
            {
                booking.DatePassed();
            }
        }

        public void ShowStatusPage(string displayText)
        {
            statusPage.txtStatus.Text = displayText;
            Main.Content = statusPage;
        }

        public void ShowEntryPage()
        {
            entryPage.txtAttendee.Text = "";
            entryPage.txtTicketCount.Text = "";

            Main.Content = entryPage;
        }

        public void ShowError(string errorText, string caption = "Error")
        {
            MessageBox.Show(this, errorText, caption);
        }

        public void ShowProcessingError()
        {
            ShowError("Processing failed. Enter a new booking", "Processing Error");
        }
    }
}
