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

        public async Task<bool> IsUserValid()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://reelweb.azurewebsites.net/");

            var response = await client.GetStringAsync("api/Users");

            foreach(var user in JsonConvert.DeserializeObject<List<User>>(response))
            {
                if(user.username.ToLower() == Username.ToLower() && user.password == Password)
                {
                    _User.id = user.id;
                    UserDB SqlDb = new UserDB();
                    var existingUser = SqlDb.GetUser(_User.id);
                    if(existingUser != null)
                    {
                        SqlDb.DeleteUser(_User.id);
                    }
                    SqlDb.AddUser(_User);
                    return true;
                }
            }
            return false;
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
