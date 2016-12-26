using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    class MainPage : AbstractPage
    {
        private const string BASE_URL = "http://onliner.by";


        [FindsBy(How = How.XPath, Using = "//DIV[@class='auth-bar__item auth-bar__item--text'][text()='Вход ']")]
        private IWebElement buttonVh;     

        [FindsBy(How = How.XPath, Using = "//BUTTON[@type='submit'][text()='Войти ']")]
        private IWebElement buttonEnter;

        [FindsBy(How = How.XPath, Using = "(//INPUT[@type='text'])[2]")]
        private IWebElement inputLogin;

        [FindsBy(How = How.XPath, Using = "(//INPUT[@type='password'])[1]")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//A[@href='https://profile.onliner.by/'][text()='radivanovich']")]
        private IWebElement userName;


        public MainPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }



        public void Login(string username, string password)
        {
            buttonVh.Click();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonEnter.Click();            
            System.Threading.Thread.Sleep(1000);
        }
        public void LogOff()
        {
            IWebElement buttonExit = driver.FindElement(By.XPath("//A[@class='exit'][text()='Выйти']"));
            buttonExit.Click();
            OpenPage();
        }
        public string GetLoggedInUserName()
        {
            return userName.Text;
        }
        public string GetAuthorizationError()
        {
            IWebElement textAuthorizationError = driver.FindElement(By.XPath("//DIV[@class='auth-box__line auth-box__line--error js-error'][text()='Неверный пароль']"));
            return textAuthorizationError.Text;
        }
        public bool isEnterButtonExists()
        {
            return buttonVh.Text.Equals("Вход ");
        }
        
    }
}
