using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysTestAutomation.Pages
{
    class Login
    {
        //Arrange
        public Login(IWebDriver webDriver)
        {
            Driver = webDriver;

        }

        public IWebDriver Driver { get; }

        IWebElement linkLogin => Driver.FindElement(By.LinkText("Login"));

        IWebElement loginModal => Driver.FindElement(By.XPath("//div[@data-backdrop=\"static\"]"));

        //Act
        public void ClickLogin()
        {
            linkLogin.Click();
        }

        public bool IsModalPopUp()
        {
            return loginModal.Displayed;
        }

    }
}
