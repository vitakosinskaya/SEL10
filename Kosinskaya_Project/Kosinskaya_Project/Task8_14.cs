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
    public class MyEighthTest
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
        public void EighthTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));

            driver.FindElement(By.CssSelector("#content a.button:first-child")).Click();
            wait.Until(ExpectedConditions.TitleIs("Add New Country | My Store"));
            List<IWebElement> list = null;
            list = new List<IWebElement>(driver.FindElements(By.CssSelector("[class*=fa-external-link]")));
            foreach (IWebElement link in list)
            {
                string mainWindow =  driver.CurrentWindowHandle;
                ICollection<string> oldWindows = driver.WindowHandles;
                link.Click();

                string newWindow = wait.Until(ThereIsWindowOtherThan(oldWindows));
                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(mainWindow);
                 
            }
                driver.Close();
        }
        private Func<IWebDriver, string> ThereIsWindowOtherThan(ICollection<string> oldWindows)
        {
            return d =>
            {
                List<string> handles = new List<string>(d.WindowHandles);
                foreach (string window in oldWindows)
                    handles.Remove(window);
                return handles.Count > 0 ? handles[0] : null;
            };
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}