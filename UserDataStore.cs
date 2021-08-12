using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Database;
using Android.Database.Sqlite;

namespace CodingApp
{
    public class UserDataStore : SQLiteOpenHelper
    {
        private static String DB_NAME = "CodingApp";
        private static int DB_VERSION = 1;
        private static String DB_TABLE = "User";
        private static String DB_COLUMN1 = "Name";
        private static String DB_COLUMN2 = "Password";

        public UserDataStore(Context context) : base(context, DB_NAME, null, DB_VERSION)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            string query = $"CREATE TABLE {UserDataStore.DB_TABLE} (ID INTEGER PRIMARY KEY AUTOINCREMENT, {UserDataStore.DB_COLUMN1} TEXT NOT NULL, {UserDataStore.DB_COLUMN2} TEXT NOT NULL );";
            db.ExecSQL(query);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            string query = $"DELETE TABLE IF EXISTS {DB_TABLE}";
            db.ExecSQL(query);
            OnCreate(db);
        }

        public bool IsUserNameExists(string name)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor cursor = db.RawQuery($"SELECT * FROM {DB_TABLE} WHERE {DB_COLUMN1} = '{name}'", null);
            if (cursor.MoveToFirst())
            {
                return true;
            }

            return false;
        }

        public void InsertNewUser(String name, string password)
        {
            SQLiteDatabase db = this.WritableDatabase;
            ContentValues values = new ContentValues();
            values.Put(DB_COLUMN1, name);
            values.Put(DB_COLUMN2, password);
            db.InsertWithOnConflict(DB_TABLE, null, values, Android.Database.Sqlite.Conflict.Replace);
            db.Close();
        }

        public void DeleteUserByName(String name)
        {
            SQLiteDatabase db = this.WritableDatabase;
            db.Delete(DB_TABLE, DB_COLUMN1 + " = ?", new String[] { name });
            db.Close();
        }

        public List<string> GetUserList()
        {
            List<string> userList = new List<string>();
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor cursor = db.Query(DB_TABLE, new string[] { DB_COLUMN1 }, null, null, null, null, null);
            while (cursor.MoveToNext())
            {
                int index = cursor.GetColumnIndex(DB_COLUMN1);
                userList.Add(cursor.GetString(index));
            }
            return userList;
        }
    }
}