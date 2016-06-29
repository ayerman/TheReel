using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TheReel
{
    public class App : Application
    {
        public App()
        {
            UserDB sqlDB = new UserDB();
            var user = sqlDB.GetUsers().FirstOrDefault();
            if(user != null)
            {

            }
            else
            {
                var NavPage = new NavigationPage();
                MainPage = NavPage;
                NavPage.PushAsync(new LoginPage(new LoginViewModel(new User())));
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
