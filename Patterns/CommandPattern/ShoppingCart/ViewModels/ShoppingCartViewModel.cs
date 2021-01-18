using ShoppingCart.Business.Commands;
using ShoppingCart.Business.Repositories;
using ShoppingCart.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ShoppingCart.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public System.Windows.Input.ICommand RemoveAllFromCartCommand { get; private set; }
        public System.Windows.Input.ICommand CheckoutCommand { get; private set; }
        public System.Windows.Input.ICommand UndoCommand { get; private set; }
        public System.Windows.Input.ICommand RedoCommand { get; private set; }
        public Business.Commands.CommandManager CommandManager { get; private set; }

        public ObservableCollection<ProductViewModel> Products { get; private set; }
        public ObservableCollection<ProductViewModel> LineItems { get; private set; }

        public ShoppingCartViewModel(
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            initializeViewModel();
        }
        private void initializeViewModel()
        {
            var removeAllFromCartCommand = new RemoveAllFromCartCommand(shoppingCartRepository, productRepository);
            var checkoutCommand = new CheckoutCommand(shoppingCartRepository);
            CommandManager = new Business.Commands.CommandManager();

            RemoveAllFromCartCommand = new RelayCommand(
                execute: () =>
                {
                    CommandManager.Invoke(removeAllFromCartCommand);
                    Refresh();
                },
                canExecute: () => removeAllFromCartCommand.CanExecute()
            );

            CheckoutCommand = new RelayCommand(
                execute: () =>
                {
                     CommandManager.Invoke(checkoutCommand);
                     MessageBox.Show($"Shopping cart total: ${checkoutCommand.Total}");
                },
                canExecute: () => checkoutCommand.CanExecute()
            );

            UndoCommand = new UndoRelayCommand(
                undo: () =>
                {
                    CommandManager.Undo();
                    Refresh();
                },
                canExecute: () => CommandManager.DoCommandsCount > 0
            );
            RedoCommand = new RedoRelayCommand(
                redo: () =>
                {
                    CommandManager.Redo();
                    Refresh();
                },
                canExecute: () => CommandManager.RedoCommandsCount > 0
            );
            Refresh();
        }

        public void Refresh()
        {
            var products = productRepository
                .All()
                .Select(
                product => new ProductViewModel(this,
                shoppingCartRepository,
                productRepository,
                product
                ));
            var lineItems = shoppingCartRepository
                .All()
                .Select(item => new ProductViewModel(this, 
                shoppingCartRepository, 
                productRepository, 
                item.Product, 
                item.Quantity));

            Products = new ObservableCollection<ProductViewModel>(products);
            LineItems = new ObservableCollection<ProductViewModel>(lineItems);
            
            // TODO: STUDY THE BENEATH FUNCTION
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(LineItems));
        }
    }
}
