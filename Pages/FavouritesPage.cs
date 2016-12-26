using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
namespace TestFramework.Pages
{
    class FavouritesPage : AbstractPage
    {
        private const string BASE_URL = "https://profile.onliner.by/bookmarks/catalog";

        [FindsBy(How = How.XPath, Using = "(//INPUT[@type='checkbox'])[2]")]
        private IWebElement checkFavourite;

        [FindsBy(How = How.XPath, Using = "//I[@class='b-ico']")]
        private IWebElement buttonDelFavourite;

        public FavouritesPage(IWebDriver driver)
            : base(driver)
        {

            PageFactory.InitElements(this.driver, this);
        }
        public void DeleteFromFavourites()
        {
            checkFavourite.Click();
            buttonDelFavourite.Click();
        }
        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }
        public int isDeletedFromFavourite()
        {
            System.Threading.Thread.Sleep(2000);
            IWebElement imgDeleteFavourite = driver.FindElement(By.XPath("(//P)[2]"));
            return imgDeleteFavourite.Text.CompareTo("Нет закладок"); ;
      
        }
    }
}
