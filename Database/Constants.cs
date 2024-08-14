using Land_Property_App.Helper;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land_Property_App.Database
{
    public static class Constants
    {
        public static string GetPath(string tableName) => FileAccessHelper.GetLocalFilePath(tableName + ".db3");

        public const SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;
    }
}
