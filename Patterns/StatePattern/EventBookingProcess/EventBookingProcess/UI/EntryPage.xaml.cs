using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace EventBookingProcess.UI
{
    /// <summary>
    /// Interaction logic for EntryPage.xaml
    /// </summary>
    public partial class EntryPage : Page
    {
        public EntryPage()
        {
            InitializeComponent();
        }

        private void ValidateNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
