using System;
using System.Collections.Generic;


namespace timetable 
{
    public class Timetable 
    {
        private Period[] periods;
        public Period[] Periods
        {
            get {
                return periods;
            }
            set {
                periods = value;
            }
        }

        public void SearchInTimetable()
        {
            Console.WriteLine("Search for semester (like MIB 4) or id of lecturer.");
            string query = Console.ReadLine();
            string[] splittedQuery = query.Split();
            bool searchForSemester = true;
            int grade = 0;
            int lecturerId = 0;
            int semesterId = 0;
            List<Semester> semester = JsonPersistence.DeserializeSemesters();
            if (splittedQuery.Length == 1)
            {
                searchForSemester = false;
                try {
                    lecturerId = Int32.Parse(splittedQuery[0]);
                } catch {
                    Console.WriteLine("Id needs to be an integer.");
                    return;
                }
            } else {
                try {
                    grade = Int32.Parse(splittedQuery[1]);
                } catch {
                    Console.WriteLine("Grade needs to be a number. Maybe you also forgot to add a space between major and grade?");
                    return;
                }
                Semester selectedSemester = semester.Find(x => x.Major == splittedQuery[0] && x.Grade == grade);
                semesterId = selectedSemester.Id;
            }
            EmitTimetable(searchForSemester, semesterId, lecturerId);
        }

        public void EmitTimetable(bool searchForSemester, int semesterId, int lecturerId)
        {
            List<int> occupiedPeriods = new List<int>();

            foreach (Period period in periods)
            {
                if (period.Elements == null)
                {
                    break;
                }

                foreach (SchedulableElement course in period.Elements)
                {
                    if(searchForSemester)
                    {
                        if (course.Course.Semesters.Exists(x => x.Id == semesterId))
                        {
                            occupiedPeriods.Add(period.Number);
                            Console.WriteLine(period.Weekday + ": " + period.StartTime + " - " + period.EndTime + " " + course.Course.Name + " - " + course.Course.Lecturer.FullName + " - " + course.Room.Name);
                        }
                    } else 
                    {
                        if (course.Course.Lecturer.Id == lecturerId)
                        {
                            Console.WriteLine(period.Weekday + ": " + period.StartTime + " - " + period.EndTime + " " + course.Course.Name + " - " + course.Room.Name);
                        }
                    }
                }
            }

            if(searchForSemester)
            {
                Console.WriteLine("Type yes if you want see which optional courses you can still take.");

                if(Console.ReadLine() == "yes")
                {
                    EmitOptionalCourses(occupiedPeriods);
                }
            }
        }

        private void EmitOptionalCourses(List<int> occupiedPeriods)
        {
            bool optionalCourseCanBeTaken = false;
            List<OptionalCourse> optionalCourses = GetSortedCourses();

            foreach (OptionalCourse optionalCourse in optionalCourses)
            {
                int courseAtPeriod = optionalCourse.AtPeriod;
                if (!occupiedPeriods.Exists(x => x == courseAtPeriod))
                {
                    if (courseAtPeriod < periods.Length)
                    {
                        optionalCourseCanBeTaken = true;
                        Period thisPeriod = periods[courseAtPeriod];
                        Console.WriteLine(thisPeriod.Weekday + ": " + thisPeriod.StartTime + " - " + thisPeriod.EndTime + " " + optionalCourse.Name + " - " + optionalCourse.Lecturer.FullName);
                    }
                }
            }

            if(!optionalCourseCanBeTaken)
            {
                Console.WriteLine("You sadly can't take any optional courses.");
            }
        }
        private static List<OptionalCourse> GetSortedCourses()
        {
            List<OptionalCourse> optionalCourses = JsonPersistence.DeserializeOptionalCourses();
            optionalCourses.Sort((x, y) => x.SortingOrder.CompareTo(y.SortingOrder));
            return optionalCourses;
        }
    }
}