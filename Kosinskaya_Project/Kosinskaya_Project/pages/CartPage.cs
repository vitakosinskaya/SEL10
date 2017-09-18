using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace csharp_example
{
    internal class CartPage : Page
    {
       
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        internal CartPage Open()
        {
            driver.Url = "http://localhost/litecart/checkout";
            return this;
        }


        [FindsBy(How = How.CssSelector, Using = ".shortcuts li.shortcut")]
        internal IList<IWebElement> shortcuts;

        internal bool IsOnThisPage()
        {
            return ExpectedConditions.TitleContains("Checkout |").Invoke(driver);
        }

        internal IWebElement CartTable()
        {
            return driver.FindElement(By.CssSelector("#order_confirmation-wrapper"));
        }

        internal IWebElement RemoveFromCartItem()
        {
            return driver.FindElement(By.Name("remove_cart_item"));
        }


        internal CartPage RemoveFromCart()
        {
            int itemsCount = shortcuts.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                var table = CartTable();
                RemoveFromCartItem().Click();
                wait.Until(ExpectedConditions.StalenessOf(table));
            }

            return this;
        }
    }
}