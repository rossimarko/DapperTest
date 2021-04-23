using Dapper;
using System;
using System.Diagnostics;

namespace DapperTest
{
    class TestSqlCode
    {
        public static Result InsertSingleRow(int maxRows)
        {

            using var con = DBHelper.GetConnection();

            Stopwatch stopWatch = new Stopwatch();            
            
            stopWatch.Start();
            for (int i = 0; i < maxRows; i++)
            {
                var u = con.QuerySingle<User>(@"INSERT INTO dbo.Users ([Name], Surname, Birthdate)
                                        OUTPUT Inserted.IDUtente, Inserted.Name, Inserted.Surname, Inserted.Birthdate
                                        VALUES (@Name, @Surname, @Birthdate)
                                        ",
                                        new { Name = $"Name {i}", Surname = $"Surname {i}", Birthdate = DateTime.Now.AddDays(-i) });
                                        

            }
            stopWatch.Stop();
                        

            return new Result() { MethodName = TestType.InsertSingleRowSql,  Rows = maxRows, ElapsedTime = stopWatch.Elapsed };            

        }



        public static Result InsertMultipleRowTVP(int maxRows)
        {

            using var con = DBHelper.GetConnection();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i < maxRows; i++)
            {
                var u = con.QuerySingle<User>(@"INSERT INTO dbo.Users ([Name], Surname, Birthdate)
                                        OUTPUT Inserted.IDUtente, Inserted.Name, Inserted.Surname, Inserted.Birthdate
                                        VALUES (@Name, @Surname, @Birthdate)
                                        ",
                                        new { Name = $"Name {i}", Surname = $"Surname {i}", Birthdate = DateTime.Now.AddDays(-i) });


            }
            stopWatch.Stop();


            return new Result() { Rows = maxRows, ElapsedTime = stopWatch.Elapsed };

        }
    }
}
