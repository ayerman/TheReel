using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using TheReel.WebService;
using Xamarin.Forms;

namespace TheReel
{
    public class App : Application
    {
        public App()
        {
            UserDB sqlDB = new UserDB();
            UserDAO UserWeb = new UserDAO();
            //cleanDB(sqlDB);
            var liteUser = sqlDB.GetUsers().FirstOrDefault();
            if(liteUser != null && UserWeb.Login(liteUser))
            {
                var newMain = new MasterDetailPage();
                newMain.Master = new NavPage(liteUser.username);
                newMain.Detail = new TopicsPage(new TopicsViewModel());
                Application.Current.MainPage = newMain;
            }
            else
            {
                var NavPage = new NavigationPage();
                MainPage = NavPage;
                NavPage.PushAsync(new LoginPage(new LoginViewModel(new User())));
            }
        }

        private void cleanDB(UserDB sqliteDB)
        {
            foreach(var user in sqliteDB.GetUsers())
            {
                sqliteDB.DeleteUser(user.id);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
