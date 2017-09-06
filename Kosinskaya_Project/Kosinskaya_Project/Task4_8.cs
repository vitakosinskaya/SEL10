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


namespace csharp_example
{
    [TestFixture]
    public class MyFourthfTest
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
        public void ThirdTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            List<IWebElement> menu = null;
            menu = new List<IWebElement>(driver.FindElements(By.CssSelector("[class*=hover-light]")));
            
            foreach (IWebElement duck in menu)
            {
               Assert.True(duck.FindElements(By.CssSelector(".sticker")).Count() == 1);
               
            }    
        
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