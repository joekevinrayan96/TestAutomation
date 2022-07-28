using JupiterToysTestAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterToysTestAutomation.Tests
{
    class TestCases
    {
        //Browser Driver
        IWebDriver webDriver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            //Navigate to site
            webDriver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/");
        }


        [Test]
        public void Homepage_IsDisplayed()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.ClickHome();

            Assert.That(homePage.titleJupiterToysDisplayed, Is.True);
        }

        [Test]
        public void ShopPage_IsDisplayed()
        {
            Shop shop = new Shop(webDriver);
            shop.ClickShop();

            Assert.That(shop.IsToysListDisplayed, Is.True);
        }

        [Test]
        public void ContactPage_IsDisplayed()
        {
            Contact contact = new Contact(webDriver);
            contact.ClickContact();

            Assert.That(contact.IsformElementDisplayed, Is.True);
        }

        [Test]
        public void LoginModal_IsDisplayed()
        {
            Login login = new Login(webDriver);
            login.ClickLogin();

            Assert.That(login.IsModalPopUp, Is.True);
        }

        [Test]
        public void CartPage_StartShoppingButton_Navigates_ShopPage()
        {
            Cart cart = new Cart(webDriver);

            Assert.That(cart.NavigatesShopPage_ShoppinItemsDisplayed, Is.True);
        }

        [Test]
        public void ShopPage_AddItemsToCart_Displayed()
        {
            Shop shop = new Shop(webDriver);
            //shop.ClickShop();
            

            Assert.That(shop.ParticularCartItemDisplayed_OnBuyButtonClick, Is.True);
        }

        //[Test]
        //public void ShopPage_AllAddedItemsToCart_Displayed()
        //{
        //    Shop shop = new Shop(webDriver);
        //    shop.ClickShop();

        //    Assert.That(shop.AllCartItemsDisplayed_ObBuyButtonsClick, Is.True);
        //}

        [Test]
        public void CartPage_CartIsEmptied_OnEmptyCartButtonClick()
        {
            Cart cart = new Cart(webDriver);
            //cart.ClickCart();
            Shop shop = new Shop(webDriver);
            shop.ClickShop();
            //shop.ClickBuyButton();
            //cart.ClickCart();
            //cart.ClickEmptyCartButton();

            Assert.That(cart.EmptyCart, Is.True);
        }

        [Test]
        public void CartPage_Navigates_CheckoutPageOnCheckoutButtonClick()
        {
            Cart cart = new Cart(webDriver);
            Assert.That(cart.CheckoutPage_Displayed, Is.True);
        }

        [Test]
        public void CartPage_CheckoutValidation_OnSubmitClick()
        {
            Cart cart = new Cart(webDriver);
            Assert.That(cart.PreventSubmit_OnEmpty_Checkout, Is.True);
        }

        //[TearDown]
        //public void TearDown() => webDriver.Quit();
    }
}
