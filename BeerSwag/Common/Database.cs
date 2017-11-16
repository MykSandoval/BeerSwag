using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerSwag.Common
{
    
    public class Database
    {
        string path;
        SQLiteConnection conn;
        public Database()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "MyDatabase.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            //create table
            conn.CreateTable<Users>();
        }
        
        public int Register(Users user)
        {
           int code = 1;
            try
            {
                conn.Insert(new Users()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email
                });
            }
            catch(SQLiteException ex)
            {
                code = -1;
            }
            return code;
        }
            
        public bool Login (string user, string password)
            {
                var query = conn.Table<Users>().
                    Where(t => t.UserName == user && t.Password == password);
                if (query.Count() > 0)
                    return true;
                else
                    return false;
            }
            
        
    }
}
