using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Compatibility;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.PageObjects;
using System.Drawing;
using System.Collections;


namespace csharp_example
{
    [TestFixture]
    public class MySeventhTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;




        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void SeventhTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));

            for (int i = 0; i < 3; i++)
            {

                driver.FindElement(By.CssSelector("#box-most-popular li:first-child a:first-child")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("add_cart_product")));
                int size = driver.FindElements(By.Name("options[Size]")).Count();
                if (size != 0)
                {
                    IWebElement element = driver.FindElement(By.Name("options[Size]"));
                    element.Click();
                    element.SendKeys("Small");
                }
                

                driver.FindElement(By.Name("add_cart_product")).Click();

                var quantity = Int32.Parse(driver.FindElement(By.CssSelector("div#cart span.quantity")).Text);
                wait.Until(ExpectedConditions.ElementExists(By.XPath(
               string.Format("//div[@id='cart']//span[@class='quantity' and .='{0}']", quantity + 1))));
              
                driver.Url = "http://localhost/litecart/en/";

            }

            driver.FindElement(By.CssSelector("#cart a:last-child")).Click();

            int item = driver.FindElements(By.CssSelector(".shortcuts li.shortcut")).Count();
            for (int i = 0; i < item; i++)
            {
                IWebElement table = driver.FindElement(By.CssSelector("#order_confirmation-wrapper"));
                driver.FindElement(By.Name("remove_cart_item")).Click();
                wait.Until(ExpectedConditions.StalenessOf(table));
            }

            Thread.Sleep(2000);
                driver.Close();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}