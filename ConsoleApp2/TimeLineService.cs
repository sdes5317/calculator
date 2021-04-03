using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    /// <summary>
    /// 負責判斷有效工時
    /// </summary>
    public class TimeLineService
    {
        private readonly Dictionary<string, bool> _timeLines = new Dictionary<string, bool>();

        public IEnumerable<WorkTime> GetWorkTime()
        {
            var timeLineList = _timeLines.Where(x => x.Value).Select(x => x.Key).ToList();
            List<WorkTime> workTimes = new List<WorkTime>();

            for (int i = 0; i < timeLineList.Count; i++)
            {
                var time = DateTime.Parse(timeLineList[i]);
                if (i == 0)
                {
                    workTimes.Add(new WorkTime(time, time));
                }
                else
                {
                    var last = DateTime.Parse(timeLineList[i - 1]);
                    if (last.AddMinutes(1) == time)
                    {
                        workTimes.Last().End = time.AddMinutes(1);
                    }
                    else
                    {
                        workTimes.Add(new WorkTime(time, time));
                    }
                }
            }

            return workTimes;
        }

        public void TimeLineProcess(List<TimeLine> timeLines)
        {
            var workLines = timeLines.Where(x => x.IsAviable);
            SetWorkTime(workLines);
            var voidLines = timeLines.Where(x => !x.IsAviable);
            SetVoidTime(voidLines);
        }

        private void SetWorkTime(IEnumerable<TimeLine> timeLines) => SetTimeLine(timeLines, true);
        private void SetVoidTime(IEnumerable<TimeLine> timeLines) => SetTimeLine(timeLines, false);

        private void SetTimeLine(IEnumerable<TimeLine> timeLines, bool value)
        {
            foreach (var timeLine in timeLines)
            {
                foreach (var time in timeLine.Time)
                {
                    if (_timeLines.ContainsKey(time))
                    {
                        _timeLines[time] = value;
                    }
                    else
                    {
                        _timeLines.Add(time, value);
                    }
                }
            }
        }
    }
}