using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;

namespace TheReel
{
    public class App : Application
    {
        public App()
        {
            UserDB sqlDB = new UserDB();
            //cleanDB(sqlDB);
            var liteUser = sqlDB.GetUsers().FirstOrDefault();
            bool result = false;
            if(liteUser != null)
            {
                //DAO this
                var client = new HttpClient();

                client.BaseAddress = new Uri("http://reelweb.azurewebsites.net/");

                var response = client.GetStringAsync("api/Users");
                response.Wait();
                
                foreach (var user in JsonConvert.DeserializeObject<List<User>>(response.Result))
                {
                    if (user.username.ToLower() == liteUser.username.ToLower() && user.password == liteUser.password)
                    {
                        result = true;
                    }
                }
            }
            if (result == false)
            {
                var NavPage = new NavigationPage();
                MainPage = NavPage;
                NavPage.PushAsync(new LoginPage(new LoginViewModel(new User())));
            }
            else
            {
                var newMain = new MasterDetailPage();
                newMain.Master = new NavPage(liteUser.username);
                newMain.Detail = new TopicsPage(new TopicsViewModel());
                Application.Current.MainPage = newMain;
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
