using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp2;
using Xunit;

namespace XUnitTestProject1
{
    public class TimeLineServiceTest
    {
        TimeLineService _timeLineService = new TimeLineService();

        [Fact]
        public void GetWorkTimeNormal()
        {
            var testData = NormalWork();

            _timeLineService.TimeLineProcess(testData.testData.ToList());
            var actually = _timeLineService.GetWorkTime().ToList();
            var except = testData.except.ToList();
            for (int i = 0; i < except.Count; i++)
            {
                Assert.Equal(except[i].ToString(), actually[i].ToString());
            }
        }

        [Fact]
        public void GetWorkTimeHasMeeting()
        {
            var testData = NormalWorkAndMeeting();

            _timeLineService.TimeLineProcess(testData.testData.ToList());
            var actually = _timeLineService.GetWorkTime().ToList();
            var except = testData.except.ToList();
            for (int i = 0; i < except.Count; i++)
            {
                Assert.Equal(except[i].ToString(), actually[i].ToString());
            }
        }



        (IEnumerable<WorkTime> except, IEnumerable<TimeLine> testData) NormalWorkAndMeeting()
        {
            var testData=new List<TimeLine>()
            {
                GetNormalWork(),
                GetMeeting()
            };

            var except = new List<WorkTime>()
            {
                new WorkTime(new DateTime(2020, 10, 10, 8, 10, 0), new DateTime(2020, 10, 10, 10, 0, 0))
            };
            return (except, testData);
        }

        (IEnumerable<WorkTime> except, IEnumerable<TimeLine> testData) NormalWork()
        {
            var testData = new List<TimeLine>()
            {
                GetNormalWork(),
            };

            var except = new List<WorkTime>()
            {
                new WorkTime(new DateTime(2020, 10, 10, 8, 0, 0), new DateTime(2020, 10, 10, 10, 0, 0))
            };
            return (except, testData);
        }

        private TimeLine GetNormalWork()
        {
            var start = new DateTime(2020, 10, 10, 8, 0, 0);
            var end = new DateTime(2020, 10, 10, 10, 0, 0);
            return new TimeLine(true, "Work", start, end);
        }
        private TimeLine GetMeeting()
        {
           var start = new DateTime(2020, 10, 10, 8, 0, 0);
           var end = new DateTime(2020, 10, 10, 8, 10, 0);
           return new TimeLine(false, "Meeting", start, end);
        }
    }
}
