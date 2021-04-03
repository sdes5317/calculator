using System.Collections.Generic;

namespace ConsoleApp2
{
    public class TimeLine
    {
        public string Name { get; set; }
        public bool IsAviable { get; set; }
        public List<string> Time { get; set; } = new List<string>();
    }
}