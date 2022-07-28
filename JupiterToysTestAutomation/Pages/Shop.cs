using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysTestAutomation.Pages
{
    public class Shop
    {
        //Arrange
        public Shop(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public IWebDriver Driver { get; }

        public string CurrentUrl { get; set; }

        IWebElement linkShop => Driver.FindElement(By.LinkText("Shop"));

        IWebElement toyInList => Driver.FindElement(By.XPath("//li//img"));

        //IWebElement buyButton => Driver.FindElement(By.XPath("//li//a[@ng-click]"));

        public IWebElement buyButton => Driver.FindElement(By.XPath("//li[@id=\"product-1\"]//a"));

        IWebElement buyButtons => (IWebElement)Driver.FindElements(By.XPath("//li//a[text()=\"Buy\"]"));

        List<IWebElement> buyButtonsCount => (List<IWebElement>)(IWebElement)Driver.FindElements(By.XPath("//li//a[text()=\"Buy\"]")).ToList();
       

        string shopItemSelectedStr => Driver.FindElement(By.XPath("(//img[@ng-src])[1]")).GetAttribute("ng-src");

        IWebElement shopItemsSelected => Driver.FindElement(By.XPath("//img[@ng-src]"));

        List<string> shopItemsSelectedStr => (List<string>)(IWebElement)Driver.FindElements(By.XPath("//img[@ng-src]")).ToList();

        IWebElement cartLink => Driver.FindElement(By.XPath("//li/a[@href=\"#/cart\"]"));

        //Act
        public void ClickShop()
        {
            linkShop.Click();
            CurrentUrl = Driver.Url;

        } 

        public void ClickBuyButton()
        {
            buyButton.Click();
        }
        
        
                

        public bool IsToysListDisplayed()
        {
            
            Driver.Navigate().GoToUrl(CurrentUrl);
            return toyInList.Displayed;
        }

        public bool ParticularCartItemDisplayed_OnBuyButtonClick()
        {
            Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/shop");
            buyButton.Click();
            cartLink.Click();
            //return shopItemSelected.Displayed;
            //return shopItemSelectedStr.Equals("images/src-embed/teddy.jpg");
            return shopItemSelectedStr.Equals("images/src-embed/teddy.jpg");
        }

        //public bool AllCartItemsDisplayed_ObBuyButtonsClick()
        //{
        //    Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/shop");
        //    buyButtons.Click();
        //    cartLink.Click();
        //    return buyButtonsCount.Count==shopItemsSelectedStr.Count;

        //}
    }
}
