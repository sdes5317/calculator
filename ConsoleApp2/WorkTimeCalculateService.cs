using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class WorkTimeCalculateService
    {
        public int Calculate(List<WorkTime> workTimes, DateTime targetTime)
        {
            var workFinish = workTimes.Where(workTime => workTime.End < targetTime).Select(workTime =>
                (workTime.End - workTime.Start).TotalSeconds).Sum();

            var workProcessing = workTimes.Where(workTime => workTime.End > targetTime && workTime.Start < targetTime)
                .Select(workTime => (targetTime - workTime.Start).TotalSeconds).Sum();

            return (int)(workFinish + workProcessing);
        }
    }
}
