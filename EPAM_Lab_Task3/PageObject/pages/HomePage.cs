using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Lab_Task3.PageObject.pages
{
    public class HomePage: BasePage
    {
        public HomePage(IWebDriver driver):base(driver) { }

        private readonly By searchField = By.XPath("//input[@name='search']");
        private readonly By searchButton = By.XPath("//button[contains(text(),'Знайти')]");

        public SearchResultPage SearchByKeyword(String keyword)
        {
            driver.FindElement(searchField).SendKeys(keyword);
            driver.FindElement(searchButton).Click();
            return new SearchResultPage(driver);
        }
    }
}
