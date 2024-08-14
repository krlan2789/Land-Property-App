using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land_Property_App.Database
{
    public class BaseRepo
    {
        protected SQLiteAsyncConnection? Database = null;

        protected void Init(string dbName)
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.GetPath(dbName), Constants.Flags);
        }
    }
}
