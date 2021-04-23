using System;

namespace DapperTest
{
    class Result
    {

        public TestType MethodName { get; set; }

        public int Rows { get; set; }

        public TimeSpan ElapsedTime { get; set; }

        public double RowPerSecond
        {
            get 
            {
                return Rows / ElapsedTime.TotalSeconds;
            }
        }

        public string ElapsedTimeDescription
        {
            get
            {
                return String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ElapsedTime.Hours, ElapsedTime.Minutes, ElapsedTime.Seconds, ElapsedTime.Milliseconds / 10);
            }
        }
    }
}
