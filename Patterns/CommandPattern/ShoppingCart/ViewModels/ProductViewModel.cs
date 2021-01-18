using ShoppingCart.Business.Commands;
using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories;
using ShoppingCart.Commands;
using static ShoppingCart.Business.Commands.ChangeQuantityCommand;

namespace ShoppingCart.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public System.Windows.Input.ICommand AddToCartCommand { get; private set; }
        public System.Windows.Input.ICommand IncreaseQuantityCommand { get; private set; }
        public System.Windows.Input.ICommand DecreaseQuantityCommand { get; private set; }
        public System.Windows.Input.ICommand RemoveFromCartCommand { get; private set; }

        public ProductViewModel(
            ShoppingCartViewModel shoppingCartViewModel,
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product,
            int quantity = 0
        )
        {
            Product = product;
            Quantity = quantity;

            var addToCartCommand = new AddToCartCommand(shoppingCartRepository, productRepository, Product);
            var increaseQuantityCommand = new ChangeQuantityCommand(Operation.Increase, shoppingCartRepository, productRepository, Product);
            var decreaseQuantityCommand = new ChangeQuantityCommand(Operation.Decrease, shoppingCartRepository, productRepository, Product);
            var removeFromCartCommand = new RemoveFromCartCommand(shoppingCartRepository, productRepository, Product);

            AddToCartCommand = new RelayCommand(execute: () =>
                {
                    shoppingCartViewModel.CommandManager.Invoke(addToCartCommand);
                    shoppingCartViewModel.Refresh();
                },
                canExecute: () => addToCartCommand.CanExecute()
                );

            IncreaseQuantityCommand = new RelayCommand(
                execute: () =>
                {
                    shoppingCartViewModel.CommandManager.Invoke(increaseQuantityCommand);
                    shoppingCartViewModel.Refresh();
                },
                canExecute: () => increaseQuantityCommand.CanExecute()
                );

            DecreaseQuantityCommand = new RelayCommand(
                execute: () =>
                {
                    shoppingCartViewModel.CommandManager.Invoke(decreaseQuantityCommand);
                    shoppingCartViewModel.Refresh();
                },
                canExecute: () => decreaseQuantityCommand.CanExecute()
                );

            RemoveFromCartCommand = new RelayCommand(
                execute: () =>
                {
                    shoppingCartViewModel.CommandManager.Invoke(removeFromCartCommand);
                    shoppingCartViewModel.Refresh();
                },
                canExecute: () => removeFromCartCommand.CanExecute()
                );
        }
    }
}
