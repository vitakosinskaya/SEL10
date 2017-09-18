using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace csharp_example
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver) { }
        
        internal MainPage Open()
        {
            driver.Url = "http://localhost/litecart/en/";
            return this;
        }

        internal bool IsOnThisPage()
        {
            return ExpectedConditions.TitleIs("Online Store | My Store").Invoke(driver);
        }

        internal IWebElement MostPopularProduct(string productName)
        {
            return driver.FindElement(By.CssSelector("#box-most-popular li:first-child a:first-child"));
        }

        internal IList<string> GetMostPopularProductNames()
        {
            var elements = driver.FindElements(By.CssSelector("div#box-most-popular div.name"));
            var names = new List<string>();
            foreach (var element in elements)
                names.Add(element.Text);
            return names;
        }

    }
}