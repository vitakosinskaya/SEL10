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
    public class MySixthTest
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
        public void SixthTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
           
            driver.FindElement(By.CssSelector("#box-account-login a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Create Account | My Store"));
            driver.FindElement(By.Name("firstname")).SendKeys("Ivan");
            driver.FindElement(By.Name("lastname")).SendKeys("Ivanov");
            driver.FindElement(By.Name("address1")).SendKeys("Ivanov");
            driver.FindElement(By.Name("postcode")).SendKeys("45455");
            driver.FindElement(By.Name("city")).SendKeys("Birmingham");
            driver.FindElement(By.CssSelector(".select2-selection__arrow")).Click(); 
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("United States" + Keys.Enter);
            Thread.Sleep(1000);

            IWebElement element = driver.FindElement(By.CssSelector(".content select:last-child")); 
            element.Click();
            element.SendKeys("Alabama");

           
            Random mail = new Random();
            int r = mail.Next(1, 100); 
            Double result = r;

            IWebElement input = driver.FindElement(By.Name("email"));
            input.SendKeys(r + "@city.com");


            driver.FindElement(By.Name("phone")).SendKeys("+79000000000");
            driver.FindElement(By.Name("password")).SendKeys("Birmingham");
            driver.FindElement(By.Name("confirmed_password")).SendKeys("Birmingham");

            driver.FindElement(By.Name("create_account")).Click();
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));

            driver.FindElement(By.CssSelector("#box-account li:last-child a")).Click();
            
            driver.FindElement(By.Name("email")).SendKeys(r + "@city.com");
            driver.FindElement(By.Name("password")).SendKeys("Birmingham");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.CssSelector("#box-account li:last-child a")).Click();


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