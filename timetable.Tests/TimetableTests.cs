using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace timetable.Tests
{
    public class TimetableTests
    {
        [Fact]
        public void CheckForDuplicateRoom()
        {
            Period[] periods = GetPeriods();
            bool result = true;


            foreach (Period period in periods)
            {
                if (period.Elements != null)
                {
                    List<SchedulableElement> courseElements = period.Elements;
                    var dupes = courseElements.GroupBy(x => new {x.Room.Name})
                    .Where(x => x.Skip(1).Any()).ToList();

                    if(dupes.Any())
                    {
                        result = false;
                    }
                }
            }
            Assert.True(result, "There are duplicate rooms.");
        }
        [Fact]
        public void CheckForDuplicateSemester()
        {
            Period[] periods = GetPeriods();
            bool result = true;

            foreach (Period period in periods)
            {
                if (period.Elements != null)
                {
                    List<SchedulableElement> courseElements = period.Elements;
                    var dupes = courseElements.GroupBy(x => new {x.Course.Semesters[0].Id})
                    .Where(x => x.Skip(1).Any()).ToList();

                    if(dupes.Any())
                    {
                        result = false;
                    }
                }
            }
            Assert.True(result, "There are duplicate semesters.");

        }
        [Fact]
        public void CheckForDuplicateLecturer() 
        {
            Period[] periods = GetPeriods();
            bool result = true;

            foreach (Period period in periods)
            {
                if (period.Elements != null)
                {
                    List<SchedulableElement> courseElements = period.Elements;
                    var dupes = courseElements.GroupBy(x => new {x.Course.Lecturer.Id})
                    .Where(x => x.Skip(1).Any()).ToList();

                    if(dupes.Any())
                    {
                        result = false;
                    }
                }
            }
            Assert.True(result, "There are duplicate lecturers.");
        }

        private Period[] GetPeriods()
        {
            Timetable timetable = JsonPersistence.DeserializeTimetable();
            return timetable.Periods;
        }
    }
}
