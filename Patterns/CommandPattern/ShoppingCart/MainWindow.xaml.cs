using ShoppingCart.Business.Repositories;
using ShoppingCart.ViewModels;
using System.Windows;

namespace ShoppingCart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new ShoppingCartViewModel(new ShoppingCartRepository(), new ProductRepository());
            DataContext = viewModel;
        }
    }
}
