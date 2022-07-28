using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JupiterToysTestAutomation.Pages
{
    class Cart
    {
        //Arrange
        public Cart(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public IWebDriver Driver { get; }
        public string CurrentUrl { get; set; }

        WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

        IWebElement linkCart => Driver.FindElement(By.XPath("//a[@href=\"#/cart\"]"));

        IWebElement startShoppingButton=>Driver.FindElement(By.XPath("//p/a[@href=\"#/shop\"]"));

        IWebElement shoppingItems => Driver.FindElement(By.XPath("(//img[@ng-src])[1]"));


        IWebElement checkOutButton => Driver.FindElement(By.XPath("//a[@href=\"#/checkout\"]"));

        //IWebElement emptyCartButton => Driver.FindElement(By.XPath("//a[text()=\"Empty Cart\"]"));

        //IWebElement emptyCartButton => wait.Until(e => e.FindElement(By.XPath("//a[text()=\"Empty Cart\"]")));

        IWebElement emptyCartButton => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[text()=\"Empty Cart\"]")));

        IWebElement emptyCartYesButton => Driver.FindElement(By.XPath("//a[@ng-click=\"empty()\"]"));

        IWebElement buyButton => Driver.FindElement(By.XPath("//li[@id=\"product-1\"]//a"));

        IWebElement deliveryDetailsTitle => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//fieldset//legend[text()=\"Delivery Details\"]")));

        //List<string> textboxesWithAsterisk =>(List<string>)(IWebElement) Driver.FindElements(By.XPath("//input//preceding::label/span")).ToList();

        //IWebElement submitCheckoutButton => Driver.FindElement(By.XPath("//button[@id=\"checkout-submit-btn\"]"));

        IWebElement submitCheckoutButton => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@id=\"checkout-submit-btn\"]")));

        string checkoutForenameTxt => Driver.FindElement(By.XPath("//input[@id=\"forename\"]")).ToString();

        IWebElement forenameErr => Driver.FindElement(By.XPath("//span[@id=\"forename-err\"]"));

        string checkoutEmailTxt => Driver.FindElement(By.XPath("//input[@id=\"email\"]")).ToString();

        IWebElement emailErr => Driver.FindElement(By.XPath("//span[@id=\"email-err\"]"));

        string checkoutAddressTxt => Driver.FindElement(By.XPath("//textarea[@id=\"address\"]")).ToString();

        IWebElement addressErr => Driver.FindElement(By.XPath("//span[@id=\"address-err\"]"));

        IWebElement cardType => Driver.FindElement(By.XPath("//option[@value=\"? undefined : undefined ?\"]"));

        IWebElement cardTypeErr => Driver.FindElement(By.XPath("(//div[@class=\"controls\"]/span[@id=\"card-err\"])[1]"));

        IWebElement cardNumber => Driver.FindElement(By.XPath("//input[@id=\"card\"]"));

        IWebElement cardNumberErr => Driver.FindElement(By.XPath("(//div[@class=\"controls\"]/span[@id=\"card-err\"])[2]"));
        IWebElement successOrder => Driver.FindElement(By.XPath("(//div/strong)[1]"));


        //Act
        public void ClickCart()
        {
            linkCart.Click();
            CurrentUrl = Driver.Url;
        }

        //public void ClickShoppingButton()
        //{
        //    startShoppingButton.Click();
        //    CurrentUrl = Driver.Url;


        //}

        public void ClickEmptyCartButton()
        {
            emptyCartButton.Click();
            emptyCartYesButton.Click();
        }



        public bool NavigatesShopPage_ShoppinItemsDisplayed()
        {
            startShoppingButton.Click();
            CurrentUrl = Driver.Url;
            Driver.Navigate().GoToUrl(CurrentUrl);
            return shoppingItems.Displayed;
        }

        public bool EmptyCart()
        {
            //linkCart.Click();
            //startShoppingButton.Click();
            //Shop shop = new Shop(Driver);
            Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/shop");
            buyButton.Click();
            linkCart.Click();
            //Driver.Navigate().GoToUrl(CurrentUrl);
            
            
            emptyCartButton.Click();
            emptyCartYesButton.Click();
            //return shoppingItems == null;
            return startShoppingButton.Displayed;
        }

        public bool CheckoutPage_Displayed()
        {
            Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/shop");
            buyButton.Click();
            linkCart.Click();
            checkOutButton.Click();
            return deliveryDetailsTitle.Displayed;            
            
        }

        public bool PreventSubmit_OnEmpty_Checkout()
        {
            Driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/shop");
            buyButton.Click();
            linkCart.Click();
            checkOutButton.Click();
            submitCheckoutButton.Click();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(checkoutEmailTxt);

            cardNumber.SendKeys("1234");
            string cardNumberStr = cardNumber.ToString();
            int cardNumberStrLength = cardNumberStr.Length;
            bool displayed = false;


            while (successOrder.Displayed)
            {


                if (checkoutForenameTxt.Equals(""))
                {
                    return forenameErr.Displayed;
                    
                }
                if (checkoutEmailTxt.Equals(""))
                {
                    return emailErr.Displayed;
                }
                if (!match.Success)
                {
                    return emailErr.Displayed;
                }
                if(checkoutAddressTxt.Equals(""))
                {
                    return addressErr.Displayed;
                }
                if (cardType != null)
                {
                    return cardTypeErr.Displayed;
                }
                if (cardNumberStrLength < 16)
                {
                    return cardNumberErr.Displayed;
                }
            }

            //else
            //{
            //    return successOrder.Displayed;
            //}

            

            
        }
    }
}
