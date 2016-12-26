using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class SearchPage : AbstractPage
    {
        private const string BASE_URL = "https://onliner.by/";


        [FindsBy(How = How.XPath, Using = "//INPUT[@class='fast-search__input']")]
        private IWebElement inputSearch;        


        [FindsBy(How = How.LinkText, Using = "Apple iPhone 5s 16GB Space Gray")]
        private IWebElement selectTov;

        

        public SearchPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);          
        }

        public void Search(string text)
        {
            inputSearch.SendKeys(text);

            selectTov.Click();
        }

        public string GetFindTov(string tov_name)
        {
            IWebElement linkTov; linkTov = driver.FindElement(By.LinkText(tov_name));
            Console.WriteLine(linkTov.Text);
            return linkTov.Text;
        }
    }
}
