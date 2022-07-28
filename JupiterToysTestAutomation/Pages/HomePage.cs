using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysTestAutomation.Pages
{
    public class HomePage
    {
        //Arrange
        public HomePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public IWebDriver Driver { get; }

        public string CurrentUrl { get; set; }

        IWebElement linkHome => Driver.FindElement(By.LinkText("Home"));

        IWebElement titleJupiterToys => Driver.FindElement(By.XPath("//h1"));

        IWebElement startShopping => Driver.FindElement(By.XPath("//p/a[@href=\"#/shop\"]"));

        //Act
        public void ClickHome()
        {
            linkHome.Click();
            CurrentUrl = Driver.Url;
        }

        void ClickStartShopping()
        {
            startShopping.Click();
        }

        public bool titleJupiterToysDisplayed()
        {
            
            Driver.Navigate().GoToUrl(CurrentUrl);
            return titleJupiterToys.Displayed;

        }

    }
}
