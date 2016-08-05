using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TheReel
{
    public partial class TopicsPage : ContentPage
    {
        public TopicsViewModel _Model;
        public TopicsPage(TopicsViewModel Model)
        {
            InitializeComponent();
            Title = "Topics";
            _Model = Model;
            BindingContext = _Model;
        }

        private void TextClick(object sender, EventArgs e)
        {

        }
    }
}
