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
    public class MyFifthfTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private static List<String> rowrow;


        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FourthTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));

            List<IWebElement> menu = null;
            menu = new List<IWebElement>(driver.FindElements(By.CssSelector(".row")));
            foreach (IWebElement countrylist in menu)
            {
                List<IWebElement> country = null;
                country = new List<IWebElement>(countrylist.FindElements(By.TagName("td")));
                if (!country[5].Text.Equals("0"))
                {
                    countrylist.FindElement(By.CssSelector("a")).Click();
                    wait.Until(ExpectedConditions.TitleIs("Edit Country | My Store"));
                    List<IWebElement> statelist = null;
                    statelist = new List<IWebElement>(driver.FindElements(By.CssSelector("#table-zones tr:not(.header)")));
                    foreach (IWebElement staterow in statelist)
                    {
                        List<IWebElement> state = null;
                        state = new List<IWebElement>(staterow.FindElements(By.TagName("td")));
                        //  String zero = "A";
                        //  if (zero.CompareTo(state[5].Text) < 0) zero = state[2].Text;
                        rowrow.Add(state[2].Text);
                    }
                    comparison(rowrow);
                    driver.Navigate().Back();
                }
            }
                        driver.Close();
        }


        private void comparison(List<String> countries)
        {
            for (int i = 0; i < countries.Count() - 2; i++)
            {
                if (countries[i].CompareTo(countries[i + 1]) < 0)
                {
                    continue;
                }
            }
            rowrow.Clear();
        }



        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}