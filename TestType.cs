using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest
{
    public enum TestType
    {
        [Description("Insert single row - Stored")]
        InsertSingleRowStored = 1,

        [Description("Insert single row - Sql In Code")]
        InsertSingleRowSql = 2,

        [Description("Insert multiple row with TVP - Stored")]
        InsertMultipleRowTVPStored = 3,

        [Description("Insert multiple row with TVP - Sql In Code")]
        InsertMultipleRowTVPSql = 4
    }
}
