using SQLite;
using TheReel.Core;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using TheReel.WinPhone;

[assembly: Dependency(typeof(SQLite_WinPhone))]
namespace TheReel.WinPhone
{
    public class SQLite_WinPhone : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "UserSqlite.db3";
            var local = ApplicationData.Current.LocalFolder.Path;
            string path = Path.Combine(local, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
