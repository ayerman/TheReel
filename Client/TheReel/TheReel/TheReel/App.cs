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
            var liteUser = sqlDB.GetUsers().FirstOrDefault();
            bool result = false; ;
            if(liteUser != null)
            {
                //DAO this
                var client = new HttpClient();

                client.BaseAddress = new Uri("http://thereelweb.azurewebsites.net/");

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
                //main page
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
