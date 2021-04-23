using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest
{
    class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=(local),1433; Initial Catalog=DapperTest; User ID=sa;Password=yourStrong(!)Password;  Application Name=DapperTest;");
        }
    }
}
