using SQLite;
using System;
using System.Collections.Generic;

namespace DDLMwin
{
    //define all the operations about database

    class DbOperation
    {
        public static String dbPath;
        public static SQLiteConnection sqc;

        public String tableName = "Ddl";
        public String[] elements = { "Name", "Time", "Id" };

        public DbOperation()
        {
            dbPath = App.path + "Ddlm.db";
            sqc = new SQLiteConnection(dbPath);
            sqc.CreateTable<Ddl>();
        }

        public static void Insert(string ddlName, DateTime ddlTime) => sqc.Insert(new Ddl() { Name = ddlName, Time = ddlTime });

        public static void Delete(int id) => sqc.Delete<Ddl>(id);

        public static List<Ddl> Select(int id) => sqc.Query<Ddl>("select * from Ddl where Id = ?", id);

        public static List<Ddl> Select() => sqc.Query<Ddl>("select * from Ddl order by time");

        public static void Update(int id, string ddlName, DateTime ddlTime) => sqc.Execute(@"update Ddl set Name=?, Time=? where id=?", ddlName, ddlTime, id);

    }

    public class Ddl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
