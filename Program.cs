using Spectre.Console;
using System;
using System.ComponentModel;
using EnumsNET;
using System.Collections.Generic;

namespace DapperTest
{
    class Program
    {


        static void Main(string[] args)
        {
            int rows = 1000;

            List<string> menu = new();
            foreach (var item in Enums.GetValues<TestType>(EnumMemberSelection.All))
            {
                menu.Add($"{(int)item} - {item.AsString(EnumFormat.Description)}");
            }


            while (1 == 1)
            {
                // Ask for the user's favorite fruits
                var tests = AnsiConsole.Prompt(
                    new MultiSelectionPrompt<string>()
                        .Title("Select the test that you want")
                        .Required()
                        .PageSize(10)
                        .AddChoices(menu));


                //Output table
                var table = new Table();
                table.AddColumn("Method name");
                table.AddColumn("Rows");
                table.AddColumn("Elapsed");
                table.AddColumn("Row per seconds");


                foreach (string test in tests)
                {
                    var index = Enums.Parse<TestType>(test.Split("-")[0]);

                    Result result = null;

                    switch (index)
                    {
                        case TestType.InsertSingleRowSql:
                            result = TestSqlCode.InsertSingleRow(rows);
                            break;


                        case TestType.InsertSingleRowStored:
                            result = TestStored.InsertSingleRow(rows);
                            break;

                    }

                    table.AddRow(result.MethodName.AsString(EnumFormat.Description), result.Rows.ToString(), result.ElapsedTimeDescription, result.RowPerSecond.ToString());

                }


                // Render the table to the console
                AnsiConsole.Render(table);
            }
        }
    }
}
