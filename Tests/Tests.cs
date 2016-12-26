using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using log4net;
using log4net.Config;

namespace TestFramework
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        private const string USERNAME = "radivanovich";
        private const string PASSWORD = "3068506";
        private const string WRONG_PASSWORD = "1234";
        private const string TEXT_TO_SEARCH = "Apple iPhone 5s 16GB Space Gray";
        private const string TEXT_COMMENT = "КРУТО";
        private const string TOV_NAME = "Apple iPhone 5s 16GB Space Gray";
        private const string NEW_PASSWORD = "7547051";
        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]

        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void LoginOnliner()
        {

            steps.LoginOnliner(USERNAME, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
        }


        [Test]

        public void LogOffOnliner()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.LogOffOnliner();
            Assert.True(steps.IsLoggedOff());
        }

        [Test]
        public void Search()
        {
            steps.SearchTov(TEXT_TO_SEARCH);
            Assert.True(steps.IsSearchedTov(TEXT_TO_SEARCH));
        }
        [Test]
        public void AddToFavourites()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.AddFavourite();
            Assert.AreEqual(0, steps.IsAddedToFavourites());
            steps.DeleteFavorite();
        }
        [Test]
        public void DeleteFromFavourites()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.AddFavourite();
            steps.DeleteFavorite();
            Assert.AreEqual(steps.IsDeletedFavourite(), 0);
        }
        [Test]
        public void WrongLoginOnliner()
        {
            steps.LoginOnliner(USERNAME, WRONG_PASSWORD);
            Assert.True(steps.IsLoggedError());
        }


        [Test]
        public void AddComment()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.CommentNews(TEXT_COMMENT);
            Assert.True(steps.IsCommentAdded());
        }
        [Test]
        public void AddAvatar()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.ChangeAvatar();

            
        }
        [Test]
        public void DeleteAvatar()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.DeleteAvatar();
            Assert.True(steps.IsNoDefaultAvatar());


        }

        [Test]
        public void AddFavouritesWithoutAuthorization()
        {
            steps.AddFavouriteWithoutAuthorization();
            Assert.True(steps.IsRegistryPage());
            
        }
        [Test]
        public void ChangePassword()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.ChangePassword(PASSWORD, NEW_PASSWORD);
            steps.LogOffOnliner();
            steps.LoginOnliner(USERNAME, NEW_PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
            steps.ChangePassword(NEW_PASSWORD, PASSWORD);
        }

        [Test]
        public void SetLike()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.SetLike();
            Assert.True(steps.IsLikeSet());
            steps.DelLike();
        }

        [Test]
        public void DeleteLike()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.SetLike();
            steps.DelLike();
            Assert.True(steps.IsLikeDelete());

        }

        [Test]
        public void SetLikeWithoutAuthorization()
        {
            steps.SetLikeWithoutAuthorization();            
            Assert.True(steps.IsLikeWithoutAuthorization());

        }

        [Test]
        public void SetLikeMyComment()
        {
            steps.LoginOnliner(USERNAME, PASSWORD);
            steps.SetLikeMyComm();
            Assert.True(steps.IsSetLikeMyComm());

        }
    }
}
