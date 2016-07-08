using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TheReel
{
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel _Model;
        public LoginPage(LoginViewModel Model)
        {
            InitializeComponent();
            _Model = Model;
            BindingContext = _Model;
        }

        async void LoginClick(object obj, EventArgs e)
        {
            var result = await _Model.IsUserValid();
            if (result)
            {
                var newMain = new MasterDetailPage();
                newMain.Master = new NavPage(_Model.Username);
                newMain.Detail = new TopicsPage();
                Application.Current.MainPage = newMain;
            }
        }

        async void SignUp(object obj, EventArgs e)
        {
            await Navigation.PushAsync(new Signup(new SignupViewModel(new User())));
        }

        private void EntryFocus(object obj, FocusEventArgs e)
        {
            if (!e.IsFocused)
            {
                LoginLayout.VerticalOptions = LayoutOptions.CenterAndExpand;
            }
            else
            {
                LoginLayout.VerticalOptions = LayoutOptions.StartAndExpand;
            }
        }
    }
}
