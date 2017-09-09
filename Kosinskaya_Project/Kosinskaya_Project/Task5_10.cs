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
    public class MyFithfTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        List<String> rowrow = new List<String>();


        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FithfTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("Geo Zones | My Store"));

            int all = driver.FindElements(By.CssSelector(".row")).Count(); 
             for (int i = 0; i < all; i++)
            { 

            List <IWebElement> menu = null;
            menu = new List<IWebElement>(driver.FindElements(By.CssSelector(".row")));
                
                List<IWebElement> country = null;
                country = new List<IWebElement>(menu[i].FindElements(By.TagName("td")));
                 country[2].FindElement(By.CssSelector("a")).Click();
                    wait.Until(ExpectedConditions.TitleIs("Edit Geo Zone | My Store"));
                    List<IWebElement> statelist = null;
                    statelist = new List<IWebElement>(driver.FindElements(By.CssSelector("#table-zones td:nth-child(3)")));
                    foreach (IWebElement staterow in statelist)
                    {
                    rowrow.Add(staterow.FindElement(By.CssSelector("[selected=selected]")).Text);
                      
                }
                    Letters(rowrow);
                   
                    driver.Navigate().Back();
            
            }
                        driver.Close();
        }


        private void Letters(List<String> names)
        {
            for (int i = 0; i < names.Count - 2; i++)
            {
                if (names[i].CompareTo(names[i + 1]) < 0)
                {
                    continue;
                }
            }
            rowrow.Clear();
        }
        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}