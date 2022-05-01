using EPAM_Lab_Task3.PageObject.pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Lab_Task3.Tests
{
    [TestFixture]
    public class CheckSumInTheCartTest:BaseTest
    {
        [TestCaseSource("testData")]
        public void CheckSumInTheCart(string searchItem, string searchFilter, string Sum)
        {
            HomePage homePage = new HomePage(driver);
            homePage.SearchByKeyword(searchItem);

            SearchResultPage searchResultPage = new SearchResultPage(driver);
            searchResultPage.SearchBrandName(searchFilter);
            searchResultPage.OrderBy();
            searchResultPage.getItemByIndex(1);

            ProductPage productPage = new ProductPage(driver);
            productPage.ClickBuyButton();
            productPage.ClickCartButton();

            CartPage cartPage = new CartPage(driver);

            Assert.Greater(cartPage.GetTotalSumFromPage(),Convert.ToDouble(Sum));
        }
    }
}
