using TheReel.Core;
using SQLite;
using Xamarin.Forms;
using TheReel.Droid;
using System.IO;

[assembly: Dependency(typeof(SQLite_Android))]
namespace TheReel.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "UserSqlite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}