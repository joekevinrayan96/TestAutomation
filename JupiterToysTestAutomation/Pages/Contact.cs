using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysTestAutomation.Pages
{
    class Contact
    {
        //Arrange
        public Contact(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public IWebDriver Driver { get; }
        public string CurrentUrl { get; set; }

        IWebElement linkContact => Driver.FindElement(By.LinkText("Contact"));
        
        string formElement => Driver.FindElement(By.XPath("//form")).GetAttribute("name");

        IWebElement submit => Driver.FindElement(By.XPath("//div[@class=\"form-actions\"]/a")); 

        //Act
        public void ClickContact()
        {
            linkContact.Click();
            CurrentUrl = Driver.Url;
            
        }
        public void ClickSubmit()
        {
            submit.Click();
        }

        public bool IsformElementDisplayed()
        {
            
            Driver.Navigate().GoToUrl(CurrentUrl);
            return formElement.Equals("form");
        }

        
    }
}
