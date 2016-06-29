using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SQLite;

namespace TheReel
{
    public class User
    {
        [PrimaryKey]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public User()
        {
            username = "";
            password = "";
        }
    }
}
