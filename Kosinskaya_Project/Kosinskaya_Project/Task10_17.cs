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
    public class MyTenthTest
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
        public void TenthTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));

            var ducks = driver.FindElements(By.CssSelector(".row>td [name*=products]")).Count;

            for (var index = 0; index < ducks; index++)
            {
                driver.FindElements(By.CssSelector("td:nth-child(3)>a[href*=\'product_id\']"))[index].Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("default_category_id")));

                foreach (var l in driver.Manage().Logs.GetLog("browser"))
                {
                    Console.WriteLine(l);
                    Assert.AreEqual(0, driver.Manage().Logs.GetLog("browser").Count);
                }

                driver.FindElement(By.Name("cancel")).Click();
                wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            }
        }

            

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}