using System;
using OpenQA.Selenium;



namespace TestFramework.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }

        public void LoginOnliner(string username, string password)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);


        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Console.WriteLine(mainPage.GetLoggedInUserName());
            return (mainPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }
        public void LogOffOnliner()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.LogOff();
        }
        public bool IsLoggedOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.isEnterButtonExists();
        }
        public void AddFavourite()
        {
            Pages.TovPage tovPage = new Pages.TovPage(driver);
            tovPage.OpenPage();
            tovPage.AddFavouriteClick();
         
        }
        public void AddFavouriteWithoutAuthorization()
        {
            Pages.TovPage tovPage = new Pages.TovPage(driver);
            tovPage.OpenPage();
            tovPage.AddFavouriteWithoutAuthorizationClick();
            System.Threading.Thread.Sleep(1000);

        }
        public int IsAddedToFavourites()
        {
            Pages.TovPage tovPage = new Pages.TovPage(driver);
            
            return tovPage.isFavourite();
        }
        public bool IsSearchedTov(string tovName)
        {
            Pages.SearchPage searchPage = new Pages.SearchPage(driver);

            return searchPage.GetFindTov(tovName).Trim().ToLower().Equals(tovName.Trim().ToLower());
        }
        public void SearchTov(string tovName)
        {
            Pages.SearchPage searchPage = new Pages.SearchPage(driver);
            searchPage.OpenPage();
            searchPage.Search(tovName);
        }
        public void DeleteFavorite()
        {
            Pages.FavouritesPage favouritePage = new Pages.FavouritesPage(driver);
            favouritePage.OpenPage();
            favouritePage.DeleteFromFavourites();
        }
        public int IsDeletedFavourite()
        {
            Pages.FavouritesPage favouritePage = new Pages.FavouritesPage(driver);
            return favouritePage.isDeletedFromFavourite();
        }
        public bool IsLoggedError()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Console.WriteLine(mainPage.GetAuthorizationError());
            return (mainPage.GetAuthorizationError().Equals("Неверный пароль"));
        }
              
        
        public void ChangeAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.LoadPicture();
            profilePage.SubmitClick();
            
        }
        public bool IsDefaultAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isDefaultImg();
        }

        public bool IsNoDefaultAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isNoDefaultImg();
        }

        public void DeleteAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.SetCheckboxDeletePhoto();
            profilePage.SubmitClick();
        }
       
        public void CommentNews(string text)
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            newsPage.OpenPage();
            newsPage.WriteComment(text);
            newsPage.ButtonAddClick();
        }
       
        public bool IsCommentAdded()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            return newsPage.isCommentAdded();
        }
        public bool IsRegistryPage()
        {
            return driver.Title.Equals("Onliner");
        }

        public void ChangePassword(string oldPassword,string newPassword)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.EnterNewPasswordInfo(oldPassword, newPassword);

        }

        public void SetLike()
        { 

            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            newsPage.OpenPage();
            newsPage.SetLikeClick();
         
        
        }

        public void DelLike()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            newsPage.OpenPage();
            newsPage.DelLick();
        }

        public bool IsLikeSet()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            return newsPage.IsLikeSet();
        }

        public bool IsLikeDelete()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            return newsPage.IsLikeDelete();
        }

        public void SetLikeWithoutAuthorization()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            newsPage.OpenPage();
            newsPage.SetLikeClick();
        }

        public bool IsLikeWithoutAuthorization()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            return newsPage.LikeWithoutAuthorization();
        }

        public void SetLikeMyComm()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            newsPage.OpenPage();
            newsPage.LikeMyComment();
        }

        public bool IsSetLikeMyComm()
        {
            Pages.NewsPage newsPage = new Pages.NewsPage(driver);
            return newsPage.IsLikeMyComment();
        }
    }

}
