using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    class TovPage : AbstractPage
    {
        private const string BASE_URL = "https://catalog.onliner.by/mobile/apple/apple_iphone5s16#login";
        private const string TOV_NAME = "Apple iPhone 5s 16GB Space Gray";
        
        [FindsBy(How = How.XPath, Using = "(//SPAN[@class='i-checkbox__faux'])[2]")]
        private IWebElement buttonAddFavourite;   
                      
        [FindsBy(How = How.XPath, Using = "(//SPAN[@class='i-checkbox__faux'])[2]")]
        private IWebElement imgAddFavouriteWithoutAuthorization;

        [FindsBy(How = How.XPath, Using = "//SPAN[@class='catalog-masthead-controls__text'][text()='В закладках']")]
        private IWebElement isAddFavouriteText;

        public TovPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        public void AddFavouriteClick()
        {
            System.Threading.Thread.Sleep(2000);
            buttonAddFavourite.Click();
        }
        public void AddFavouriteWithoutAuthorizationClick()
        {
            imgAddFavouriteWithoutAuthorization.Click();
        }
        public int isFavourite()
        {
            System.Threading.Thread.Sleep(2000);
            return isAddFavouriteText.Text.CompareTo("В закладках"); ;
        }
        
       
    }
}
