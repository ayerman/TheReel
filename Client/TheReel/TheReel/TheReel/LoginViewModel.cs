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
    public class LoginViewModel : INotifyPropertyChanged
    {
        private User _User;
        private string _Result;

        public LoginViewModel(User user)
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

        public async void getUsers()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8905/");

            var response = await client.GetStringAsync("api/Users");

            foreach(var user in JsonConvert.DeserializeObject<List<User>>(response))
            {
                if(user.username.ToLower() == Username.ToLower() && user.password == Password)
                {
                    Result = "Success";
                    return;
                }
            }
            Result = "Failed";
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
