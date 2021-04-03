using System;
using System.Drawing;

namespace ConsoleApp2
{
    public class WorkTime
    {
        public WorkTime(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}