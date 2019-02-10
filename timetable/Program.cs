using System;
using System.Collections.Generic;

namespace timetable
{
    public class Program
    {
        static void Main(string[] args)
        {
            PersistenceDump.AddSemester();
            PersistenceDump.AddRooms();
            PersistenceDump.AddPeriods();
            PersistenceDump.AddCourses();            
            Timetable timetable;
            Console.WriteLine("Type yes if you want to do the calculation; otherwise the most recent calculated timetable is used.");
            if (Console.ReadLine() == "yes")
            {
                timetable = TimetableCalculator.CalculateTimetable();
            } else {
                timetable = JsonPersistence.DeserializeTimetable();
            }

            while (true)
            {
                timetable.SearchInTimetable();
                Console.WriteLine("Type yes if you want to see another timetable.");
                if (Console.ReadLine() != "yes")
                {
                    break;
                }
            }
        }
    }
}
