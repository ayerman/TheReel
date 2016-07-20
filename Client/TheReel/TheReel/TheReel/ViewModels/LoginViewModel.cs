using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net.Http;
using TheReel.WebService;

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

        public bool IsUserValid()
        {
            UserDAO UserWeb = new UserDAO();
            if (UserWeb.Login(_User))
            {
                UserDB SqlDb = new UserDB();
                foreach(var user in SqlDb.GetUsers())
                {
                    SqlDb.DeleteUser(user.id);
                }
                SqlDb.AddUser(_User);
                return true;
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
