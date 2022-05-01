using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Lab_Task3.PageObject.pages
{
    public class ProductPage:BasePage
    {
        public ProductPage(IWebDriver driver):base(driver) { }

        private readonly By buyButton = By.XPath("//button[contains(@class,'buy-button')]//span[contains(text(),'Купити')]");
        private readonly By cartButton = By.XPath("//li[contains(@class,'item--cart')]//button");

        public void ClickBuyButton()
        {
            WaitUntilElementExists(buyButton);
            driver.FindElement(buyButton).Click();
        }

        public CartPage ClickCartButton()
        {
            WaitUntilElementExists(cartButton);
            driver.FindElement(cartButton).Click();
            return new CartPage(driver);
        }
    }
}
