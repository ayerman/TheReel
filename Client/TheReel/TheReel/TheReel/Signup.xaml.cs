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
            Title = "The Reel";
            InitializeComponent();
            _Model = Model;
            BindingContext = _Model;
        }

        private void ConfirmClick(object obj, EventArgs e)
        {
            _Model.createUser();
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
