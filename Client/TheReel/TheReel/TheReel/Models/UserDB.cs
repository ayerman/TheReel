using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using TheReel.Core;


namespace TheReel
{
    public class UserDB
    {
        private SQLiteConnection _SQLConnection;

        public UserDB()
        {
            _SQLConnection = DependencyService.Get<ISQLite>().GetConnection();
            _SQLConnection.CreateTable<User>();
        }

        //Get all students  
        public IEnumerable<User> GetUsers()
        {
            return (from t in _SQLConnection.Table<User>() select t).ToList();
        }

        //Get specific student  
        public User GetUser(int id)
        {
            return _SQLConnection.Table<User>().FirstOrDefault(t => t.id == id);
        }

        //Delete specific student  
        public void DeleteUser(int id)
        {
            _SQLConnection.Delete<User>(id);
        }

        //Add new student to DB  
        public void AddUser(User student)
        {
            _SQLConnection.Insert(student);
        }
    }
}
