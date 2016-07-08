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
            Title = "Hello " + username;
            BackgroundColor = Color.White;
            InitializeComponent();
        }
    }
}
