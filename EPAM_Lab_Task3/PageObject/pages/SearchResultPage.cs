using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPAM_Lab_Task3.PageObject.pages
{
    public class SearchResultPage:BasePage
    {
        public SearchResultPage(IWebDriver driver):base(driver) { }

        private readonly By brandFilter = By.XPath("//span[contains(text(),'Бренд')]//..//..//a[@class='checkbox-filter__link']");
        private readonly By brandSearchField = By.XPath("//input[@name='searchline']");
        private readonly By orderBySelect = By.XPath("//select[contains(@class,'select-css')]");
        private readonly By itemList = By.XPath("//a[@class='goods-tile__picture ng-star-inserted']");

        public void SearchBrandName(string filterName)
        {
            WaitUntilElementExists(brandSearchField);
            driver.FindElement(brandSearchField,timeToWait).SendKeys(filterName);
            IList<IWebElement> brandList = driver.FindElements(brandFilter,timeToWait);

            for(int i=0;i<brandList.Count;i++)
            {
                WaitUntilElementExists(brandFilter);
                brandList = driver.FindElements(brandFilter, timeToWait);
                string Value = brandList.ElementAt(i).GetAttribute("data-id");
                if (Value.Equals(filterName))
                {
                    WaitUntilElementExists(brandFilter);
                    brandList = driver.FindElements(brandFilter, timeToWait);
                    brandList.ElementAt(i).Click();
                    break;
                }
            }
        }

        public void OrderBy()
        {
            IWebElement selectObj = driver.FindElement(orderBySelect);
            selectObj.Click();
            var selectObject = new SelectElement(selectObj);
            selectObject.SelectByValue("2: expensive");
        }

        public ProductPage getItemByIndex(int index)
        {
            WaitUntilElementExists(itemList);
            driver.FindElements(itemList).ElementAt(index).Click();
            return new ProductPage(driver);
        }

    }
}
