using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class TimeLine
    {
        public string Name { get; set; }
        public bool IsAviable { get; set; }
        public List<string> Time { get; set; }
        public TimeLine(bool isAviable, string name, DateTime start, DateTime end)
        {

            IsAviable = isAviable;
            Name = name;
            Time = new List<string>();
            for (int i = 0; i < (end - start).TotalMinutes; i++)
            {
                Time.Add(start.AddMinutes(i).ToString("yyyy-M-d HH:mm"));
            }
        }
    }
}