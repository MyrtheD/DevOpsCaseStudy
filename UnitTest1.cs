using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium.Safari;
using System.Collections.Generic;
using System.Web;

namespace Web_Scraping
{
    internal class webScraperICT
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://lommel.bibliotheek.be/");
        }

        [Test]
        public void ScrapeYouTubeTitles()
        {
            var element = driver.FindElement(By.XPath("//*[@id=\"edit-search-query-label\"]\r\n"));
            element.SendKeys("fantasy");
            element.Submit();

            var titles = driver.FindElements(By.ClassName("catalog-item-title-link"));
            foreach (var title in titles)
            {
                Console.WriteLine(title.Text);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
