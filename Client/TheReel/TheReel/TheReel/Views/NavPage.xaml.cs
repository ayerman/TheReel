using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TheReel
{
    public partial class NavPage : ContentPage
    {
        public NavPage(string username)
        {
            InitializeComponent();
            Title = "Hello " + username;
            BackgroundColor = Color.White;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            UserDB SqlDb = new UserDB();
            foreach (var user in SqlDb.GetUsers())
            {
                SqlDb.DeleteUser(user.id);
            }
            var NavPage = new NavigationPage();
            NavPage.PushAsync(new LoginPage(new LoginViewModel(new User())));
            Application.Current.MainPage = NavPage;
        }
    }
}
