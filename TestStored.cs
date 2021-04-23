using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperTest
{
    class TestStored
    {

        public static Result InsertSingleRow(int maxRows)
        {

            using var con = DBHelper.GetConnection();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i < maxRows; i++)
            {
                con.QuerySingle("proc_Users_Insert", new { Name = $"Name {i}", Surname = $"Surname {i}", Birthdate = DateTime.Now.AddDays(-i) }, commandType: System.Data.CommandType.StoredProcedure);
            }

            stopWatch.Stop();


            return new Result() { MethodName = TestType.InsertSingleRowStored,  Rows = maxRows, ElapsedTime = stopWatch.Elapsed };

        }


        public static Result InsertMultipleRowsTVP(int maxRows)
        {

            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Surname");
            dt.Columns.Add("Birthdate", typeof(DateTime));

            for (int i = 0; i < 5; i++)
            {
                dt.Rows.Add($"Name {i}", $"Surname {i}", DateTime.Now.AddDays(-i));
            }

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            stopWatch.Stop();


            return new Result() { Rows = maxRows, ElapsedTime = stopWatch.Elapsed };


        }
    }
}