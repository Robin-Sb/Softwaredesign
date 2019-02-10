using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace timetable 
{
    public class JsonPersistence 
    {
        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        public static void SerializeCourses(List<Course> courses) 
        {
            string jsonCourses = JsonConvert.SerializeObject(courses, settings);
            System.IO.File.WriteAllText(@"..\timetable\courses.json", jsonCourses);
        }
        public static List<Course> DeserializeCourses() 
        {
            return JsonConvert.DeserializeObject<List<Course>>(File.ReadAllText(@"..\timetable\courses.json"), settings);
        }
        public static void SerializeSemesters(List<Semester> semester) 
        {
            string jsonSemester = JsonConvert.SerializeObject(semester, settings);
            System.IO.File.WriteAllText(@"..\timetable\semester.json", jsonSemester);
        }
        public static List<Semester> DeserializeSemesters() 
        {
            return JsonConvert.DeserializeObject<List<Semester>>(File.ReadAllText(@"..\timetable\semester.json"), settings);
        }

        public static void SerializeRooms(List<Room> rooms) 
        {
            string jsonRooms = JsonConvert.SerializeObject(rooms, settings);
            System.IO.File.WriteAllText(@"..\timetable\rooms.json", jsonRooms);
        }
        public static List<Room> DeserializeRooms() 
        {
            return JsonConvert.DeserializeObject<List<Room>>(File.ReadAllText(@"..\timetable\rooms.json"), settings);
        }
        public static void SerializeLecturer(List<Lecturer> lecturer) 
        {
            string jsonLecturer = JsonConvert.SerializeObject(lecturer, settings);
            System.IO.File.WriteAllText(@"..\timetable\lecturer.json", jsonLecturer);
        }

        public static void SerializePeriods(Period[] periods) 
        {
            string jsonPeriods = JsonConvert.SerializeObject(periods, settings);
            System.IO.File.WriteAllText(@"..\timetable\periods.json", jsonPeriods);
        }
        public static Period[] DeserializePeriods()
        {
            return JsonConvert.DeserializeObject<Period[]>(File.ReadAllText(@"..\timetable\periods.json"), settings);
        }
        public static void SerializeTimetable(Timetable timetable) 
        {
            string jsonTimetable = JsonConvert.SerializeObject(timetable, settings);
            System.IO.File.WriteAllText(@"..\timetable\timetable.json", jsonTimetable);
        }
        public static Timetable DeserializeTimetable()
        {
            return JsonConvert.DeserializeObject<Timetable>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory + "/timetable.json")), settings);
        }

        public static void SerializeOptionalCourses(List<OptionalCourse> optionalCourse) 
        {
            string jsonOptionalCourse = JsonConvert.SerializeObject(optionalCourse, settings);
            System.IO.File.WriteAllText(@"..\timetable\optional_courses.json", jsonOptionalCourse);
        }
        public static List<OptionalCourse> DeserializeOptionalCourses()
        {
            return JsonConvert.DeserializeObject<List<OptionalCourse>>(File.ReadAllText(@"..\timetable\optional_courses.json"), settings);
        }
    }
}