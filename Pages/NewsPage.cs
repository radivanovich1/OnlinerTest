using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
     
    class NewsPage : AbstractPage
    {
        private const string BASE_URL = "https://tech.onliner.by/2016/12/26/xiaomi-best";


        [FindsBy(How = How.XPath, Using = "(//TEXTAREA[@placeholder='Ваше мнение, radivanovich?'])[1]")]
        private IWebElement commentBox;

        [FindsBy(How = How.LinkText, Using = "Высказаться")]
        private IWebElement submBtn;
        
        [FindsBy(How = How.XPath, Using = "//A[@id='addlike_2188229']")]
        private IWebElement like;

        [FindsBy(How = How.XPath, Using = "//A[@id='removelike_2188229']")]
        private IWebElement Dellike;

        [FindsBy(How = How.XPath, Using = "//BUTTON[@type='submit'][text()='Войти ']")]
        private IWebElement login;

        [FindsBy(How = How.XPath, Using = "//A[@id='addlike_2188622']")]
        private IWebElement likeMyComment;
        [FindsBy(How = How.XPath, Using = "//DIV[@id='ONotice']")]
        private IWebElement onlNotice;



        public NewsPage(IWebDriver driver): base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }
        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        
        public void WriteComment(string text)
        {
            commentBox.SendKeys(text);
        }
        public void ButtonAddClick()
        {
            submBtn.Click();
            System.Threading.Thread.Sleep(1500);
        }
        public bool isCommentAdded()
        {
            IWebElement comment = driver.FindElement(By.XPath("//P[text()='КРУТО']"));
            return comment.Text.Equals("КРУТО");
        }

        public void SetLikeClick()
        {
            like.Click();
        }

        public void DelLick()
        {
            Dellike.Click();
        }

        public bool IsLikeSet()
        {
            return Dellike.GetAttribute("id").Equals("removelike_2188229");
        }

        public bool IsLikeDelete()
        {
            return like.GetAttribute("id").Equals("addlike_2188229");
        }

        public bool LikeWithoutAuthorization()
        {
            return login.Text.Equals("Войти");
        }

        public void LikeMyComment()
        {
            likeMyComment.Click();
        }

        public bool IsLikeMyComment()
        {
            return onlNotice.Text.Equals("Нельзя голосовать за свой комментарий");
        }
    }
}
