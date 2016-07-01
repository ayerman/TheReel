using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net.Http;

namespace TheReel
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        private User _User;
        private string _ConfirmPass;
        private string _Result;

        public SignupViewModel(User user)
        {
            _User = user;
        }

        public string Username
        {
            get { return _User.username; }
            set
            {
                if (value == _User.username)
                    return;
                _User.username = value;
                NotifyPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _User.password; }
            set
            {
                if (value == _User.password)
                    return;
                _User.password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public string ConfirmPassword
        {
            get { return _ConfirmPass; }
            set
            {
                if (value == _ConfirmPass)
                    return;
                _ConfirmPass = value;
                NotifyPropertyChanged("ConfirmPassword");
            }
        }

        public string Result
        {
            get { return _Result; }
            set
            {
                if (value == _Result)
                    return;
                _Result = value;
                NotifyPropertyChanged("Result");
            }
        }

        public async void createUser()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://thereelweb.azurewebsites.net/");
            var serialized = JsonConvert.SerializeObject(_User);
            StringContent queryString = new StringContent(serialized);

            var response = await client.PostAsync("api/Users", queryString);
            if (response.IsSuccessStatusCode)
            {
                Result = "Success";
            }
            else
            {
                Result = "Failed";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
