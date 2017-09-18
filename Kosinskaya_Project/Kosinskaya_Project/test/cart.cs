using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;


namespace csharp_example
{
    [TestFixture]
    public class CartTests : TestBase
    {
        [Test]
        public void CartTest()
        {
            app.AddToCart(3);
            app.RemoveFromCart();
          
        }
    }
}