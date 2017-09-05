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
    public class MyTherdfTest
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
        public void SecondTest()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            int menu = driver.FindElements(By.CssSelector("#box-apps-menu li#app-")).Count();
            for (int i = 0; i < menu; i++)
            { driver.FindElements(By.CssSelector("#box-apps-menu li#app-"))[i].Click();
                int submenu = driver.FindElements(By.CssSelector(".docs li")).Count();
                if (submenu == 0)
                {
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h1"))); // мне кажется, что логично подождать заголовок, как я понимаю это покрывает проверку его наличия 
                    continue;
                }
                for (int j = 1; j < submenu; j++)
                {
                    driver.FindElements(By.CssSelector(".docs li"))[j].Click();
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h1")));
                }
                driver.FindElement(By.CssSelector("[class*=fa-home]")).Click();
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