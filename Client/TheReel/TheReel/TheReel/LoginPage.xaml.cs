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

        private void LoginClick(object obj, EventArgs e)
        {
            var result = _Model.getUsers();
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
