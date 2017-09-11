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
using System.IO;

namespace csharp_example
{
    [TestFixture]
    public class MySixthBTest
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
        public void SixthBTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
           
            driver.FindElement(By.CssSelector("#content a.button:last-child")).Click();
            wait.Until(ExpectedConditions.TitleIs("Add New Product | My Store"));
            driver.FindElement(By.Name("name[en]")).SendKeys("BigDuck");
            driver.FindElement(By.Name("code")).SendKeys("123");
            driver.FindElement(By.Name("quantity")).SendKeys("50");
            

            var sourceFile = Path.GetFullPath(@"\0.jpeg");
            IWebElement input = driver.FindElement(By.Name("new_images[]"));            
            input.SendKeys(sourceFile);
            driver.FindElement(By.Name("date_valid_from")).SendKeys("01092017");
            driver.FindElement(By.Name("date_valid_to")).SendKeys("01092018");

            driver.FindElement(By.CssSelector(".index li:nth-child(2)")).Click();
            Thread.Sleep(1000); //небольшая пауза)
            IWebElement element = driver.FindElement(By.Name("manufacturer_id"));
            element.Click();
            element.SendKeys("ACME Corp.");
            driver.FindElement(By.Name("keywords")).SendKeys("bestduck");
            driver.FindElement(By.Name("short_description[en]")).SendKeys("best duck");
            driver.FindElement(By.CssSelector(".trumbowyg-editor")).SendKeys("best duck ever");
            driver.FindElement(By.Name("head_title[en]")).SendKeys("kingduck");
            driver.FindElement(By.Name("meta_description[en]")).SendKeys("meta");


            driver.FindElement(By.CssSelector(".index li:nth-child(4)")).Click();
            Thread.Sleep(1000); //небольшая пауза)
            driver.FindElement(By.Name("purchase_price")).Clear();
            driver.FindElement(By.Name("purchase_price")).SendKeys("50");
            IWebElement elementB = driver.FindElement(By.Name("purchase_price_currency_code"));
            elementB.Click();
            elementB.SendKeys("USD");
            driver.FindElement(By.Name("save")).Click();

            driver.FindElement(By.CssSelector("#doc-catalog")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            driver.FindElement(By.CssSelector("[class*=semi-transparent] a")).Click();

            wait.Until(ExpectedConditions.TitleIs("Edit Product: BigDuck | My Store")); 

            
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