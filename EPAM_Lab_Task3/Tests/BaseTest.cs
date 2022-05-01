using log4net;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace EPAM_Lab_Task3.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private string url = "https://rozetka.com.ua/ua/";

        public static IEnumerable testData => GetTestDataXml();
        private static IEnumerable GetTestDataXml()
        {
            string XMLpath = Directory.GetCurrentDirectory() + @"\resources\Data.xml";
            var doc = XDocument.Load(XMLpath);
            return
            from testdata in doc.Descendants("testdata")
            let searchItem = testdata.Attribute("searchItem").Value
            let searchFilter = testdata.Attribute("filter").Value
            let Sum = testdata.Attribute("sum").Value
            select new object[] { searchItem, searchFilter, Sum };
        }


        

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
