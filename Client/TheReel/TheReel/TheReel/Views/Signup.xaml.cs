using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TheReel
{
    public partial class Signup : ContentPage
    {
        public SignupViewModel _Model;
        public Signup(SignupViewModel Model)
        {
            InitializeComponent();
            _Model = Model;
            BindingContext = _Model;
        }

        async void ConfirmClick(object obj, EventArgs e)
        {
            var result = await _Model.createUser();
            if (result)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage(new LoginViewModel(_Model.User)));
            }
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
