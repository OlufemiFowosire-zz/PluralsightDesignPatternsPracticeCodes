using ShoppingCart.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Commands
{
    public class CheckoutCommand : ICommand
    {
        public double Total { get; private set; }
        private readonly IShoppingCartRepository shoppingCartRepository;

        public CheckoutCommand(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public bool CanExecute()
        {
            return shoppingCartRepository.All().Any();
        }

        public void Execute()
        {
            Total = shoppingCartRepository.All().Sum(item => item.Product.Amount * item.Quantity);
        }

        public void Undo()
        {
            Total = 0.0;
        }
    }
}
