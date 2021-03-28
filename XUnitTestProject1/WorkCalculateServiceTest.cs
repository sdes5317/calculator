using System;
using System.Collections;
using System.Collections.Generic;
using ConsoleApp2;
using Xunit;

namespace XUnitTestProject1
{
    public class WorkCalculateServiceTest
    {
        private readonly WorkTimeCalculateService _calculateService = new WorkTimeCalculateService();


        [Theory]
        [ClassData(typeof(WorkTimeTestData))]
        public void Test1(IEnumerable<WorkTime> workTimes, DateTime targetTime, int exceptSecond)
        {

            Assert.Equal(exceptSecond, _calculateService.Calculate(workTimes, targetTime));
        }
    }
    public class WorkTimeTestData : IEnumerable<object[]>
    {
        private static List<WorkTime> GetWorkTimes() => new List<WorkTime>()
        {
            new WorkTime(new DateTime(2020, 10, 10, 8, 10, 0), new DateTime(2020, 10, 10, 10, 0, 0)),
            new WorkTime(new DateTime(2020, 10, 10, 10, 20, 0), new DateTime(2020, 10, 10, 12, 0, 0)),
            new WorkTime(new DateTime(2020, 10, 10, 13, 0, 0), new DateTime(2020, 10, 10, 17, 0, 0))
        };
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetWorkTimes(), new DateTime(2020, 10, 10, 10, 15, 0), 110 * 60 };
            yield return new object[] { GetWorkTimes(), new DateTime(2020, 10, 10, 8, 50, 0), 40 * 60 };
            yield return new object[] { GetWorkTimes(), new DateTime(2020, 10, 10, 12, 30, 0), 210 * 60 };
            yield return new object[] { GetWorkTimes(), new DateTime(2020, 10, 10, 15, 30, 0), 360 * 60 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
