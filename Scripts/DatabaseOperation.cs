using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace DDLM
{
    class DatabaseOperation
    {
        public static String dbPath;
        public static SQLiteConnection sqc;

        public String tableName = "Ddl";
        public String[] elements = {
            "Id", "Name", "Priority", "StartTime", "EndTime", "IsChinese", "IsLoop", "LoopInterval", "IsRemind", "RemindTime", "RemindInterval"
        };

        public DatabaseOperation()
        {
            dbPath = App.path + "Ddlm.db";
            sqc = new SQLiteConnection(dbPath);
            sqc.CreateTable<Ddl>();
        }

        public static void Insert(Ddl ddl) => sqc.Insert(ddl);

        public static void Delete(int id) => sqc.Delete<Ddl>(id);

        public static List<Ddl> Select(int id) => sqc.Query<Ddl>("select * from Ddl where Id = ?", id);

        public static List<Ddl> Select()
        {
            DateTime now = DateTime.Now;
            List<Ddl> validDdlList = sqc.Query<Ddl>("select * from Ddl where EndTime>" + now.Ticks + " order by Priority DESC, EndTime");
            List<Ddl> expiredDdlList = sqc.Query<Ddl>("select * from Ddl where EndTime<=" + now.Ticks + " order by Priority DESC, EndTime");

            return validDdlList.Concat(expiredDdlList).ToList();
        }

        public static void Update(Ddl ddl) => sqc.Execute(@"update Ddl set Name=?, Priority=?, StartTime=?, EndTime=?, IsChineseCalender=?, IsLoop=?, LoopInterval=?, Inform=?, IsRemind=?, RemindTime=?, RemindInterval=? where id=?",
            ddl.Name, ddl.Priority, ddl.StartTime, ddl.EndTime, ddl.IsChineseCalender, ddl.IsLoop, ddl.LoopInterval, ddl.Inform, ddl.IsRemind, ddl.RemindTime, ddl.RemindInterval, ddl.Id);

        public static void Update(Ddl ddl, string s, object o) => sqc.Execute(@"update Ddl set " + s + "=? where id=?", o, ddl.Id);
        
        public static void Update(int id, string s, object o) => sqc.Execute(@"update Ddl set " + s + "=? where id=?", o, id);


    }
}
