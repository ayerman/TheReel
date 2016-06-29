using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using TheReel.Core;


namespace TheReel.Models
{
    public class UserDB
    {
        private SQLiteConnection _SQLConnection;

        public UserDB()
        {
            _SQLConnection = DependencyService.Get<ISQLite>().GetConnection();
            _SQLConnection.CreateTable<UserDB>();
        }

        //Get all students  
        public IEnumerable<User> GetStudents()
        {
            return (from t in _SQLConnection.Table<User>() select t).ToList();
        }

        //Get specific student  
        public User GetStudent(int id)
        {
            return _SQLConnection.Table<User>().FirstOrDefault(t => t.id == id);
        }

        //Delete specific student  
        public void DeleteStudent(int id)
        {
            _SQLConnection.Delete<User>(id);
        }

        //Add new student to DB  
        public void AddStusent(User student)
        {
            _SQLConnection.Insert(student);
        }
    }
}
