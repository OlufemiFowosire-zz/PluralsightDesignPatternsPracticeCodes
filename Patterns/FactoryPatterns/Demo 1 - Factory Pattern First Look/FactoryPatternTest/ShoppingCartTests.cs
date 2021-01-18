using Factory_Pattern_First_Look.Business;
using Factory_Pattern_First_Look.Business.Models.Commerce;
using System;
using Xunit;

namespace FactoryPatternTest
{
    public class ShoppingCartTests
    {
        [Fact]
        public void FinalizeOrderWithoutPurchaseProvider_ThrowsException()
        {
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.GetOrder();
            var cart = new ShoppingCart(order, null);
            Assert.Throws<NullReferenceException>(() => cart.Finalize());
        }

        [Fact]
        public void FinalizeOrderWithSwedenPurchaseProvider_GenerateShippingLabel()
        {
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.GetOrder();
            var purchaseProviderFactory = new SwedenPurchaseProviderFactory();
            
            var cart = new ShoppingCart(order, purchaseProviderFactory);
            
            var label = cart.Finalize();
            
            Assert.NotNull(label);
        }
    }
}
