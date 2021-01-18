using EventBookingProcess_.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace EventBookingProcess_
{
    /// <summary>
    /// Interaction logic for EntryPage.xaml
    /// </summary>
    public partial class EntryPage : Page
    {
        public EntryPage(BookingViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void ValidateNumber(Object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
