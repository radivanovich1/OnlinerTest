using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestFramework.Pages
{
    class ProfilePage : AbstractPage
    {
        private const string BASE_URL = "https://profile.onliner.by/";

        [FindsBy(How = How.XPath, Using = "//A[@href='/edit'][text()='Редактировать личные данные']")]
        private IWebElement linkEditProfile;

        [FindsBy(How = How.XPath, Using = "//IMG[@id='user_avatar']")]
        private IWebElement imgProfile;

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='delete_avatar']")]
        private IWebElement checkboxDeletePhoto;

        [FindsBy(How = How.XPath, Using = "//A[@href='#edit/avatar'][text()='Аватар']")]
        private IWebElement changePhoto;

        [FindsBy(How = How.XPath, Using = "(//SPAN[text()='Сохранить'])[3]")]
        private IWebElement subm;

        [FindsBy(How = How.XPath, Using = "//DIV[@id='onlNotice']")]
        private IWebElement onlNotice;


        public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }
        public void EditProfileClick()
        {
            linkEditProfile.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public void LoadPicture()
        {

            changePhoto.Click();
            IWebElement inputChooseFile = driver.FindElement(By.XPath("//INPUT[@id='qq-input']"));
            inputChooseFile.SendKeys(System.IO.Path.GetFullPath(@"TestFramework/img/images.jpg"));
            System.Threading.Thread.Sleep(5000);
            

        }
        public void SubmitClick()
        {
            IWebElement buttonSubmit = driver.FindElement(By.XPath("(//SPAN[text()='Сохранить'])[3]"));
            buttonSubmit.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool isDefaultImg()
        {
            return onlNotice.Text.Equals("Аватар загружен");
        }
        public bool isNoDefaultImg()
        {
            return onlNotice.Text.Equals("Аватар удалён");
        }

        public void SetCheckboxDeletePhoto()
        {
            changePhoto.Click();
            checkboxDeletePhoto.Click();
            subm.Click();
            driver.SwitchTo().Alert().Accept();



        }
        public void EnterNewPasswordInfo(string oldPassword,string newPassword)
        {
            IWebElement changePass = driver.FindElement(By.XPath("//A[@href='#edit/password'][text()='Пароль']"));
            changePass.Click();
            IWebElement inputOldPassword = driver.FindElement(By.XPath("//INPUT[@id='old_password']"));
            inputOldPassword.SendKeys(oldPassword);
            IWebElement inputNewPassword = driver.FindElement(By.XPath("//INPUT[@id='password']"));
            inputNewPassword.SendKeys(newPassword);
            IWebElement inputRepeat = driver.FindElement(By.XPath("//INPUT[@id='password_confirm']"));
            inputRepeat.SendKeys(newPassword);
            IWebElement buttonSubmit = driver.FindElement(By.XPath("//SPAN[text()='Изменить пароль']"));
            buttonSubmit.Click();
        }
    }
}
