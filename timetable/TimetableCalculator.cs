using System;
using System.Collections.Generic;
using System.Linq;

namespace timetable 
{
    class TimetableCalculator 
    {
        public static Timetable CalculateTimetable() 
        {
            List<Course> courses = GetSortedCourses(JsonPersistence.DeserializeCourses());
            Timetable timetable = new Timetable();
            Period[] periods = JsonPersistence.DeserializePeriods();
            List<Room> rooms = GetSortedRooms(JsonPersistence.DeserializeRooms());

            List<Course> leftoverCourses = new List<Course>();
            foreach (Course course in courses) 
            {
                Course leftover = CalcForCourse(course, periods, rooms);

                if (leftover != null)
                {
                    leftoverCourses.Add(leftover);
                }
            }

            if (leftoverCourses.Count > 0)
            {
                RetryLeftoverCourses(leftoverCourses, periods, rooms);
            }

            timetable.Periods = periods;
            JsonPersistence.SerializeTimetable(timetable);
            return timetable;
        }
        private static List<Room> GetSortedRooms(List<Room> rooms)
        {
            rooms.Sort((x, y) => x.Size.CompareTo(y.Size));
            return rooms;
        }

        private static List<Course> GetSortedCourses(List<Course> courses)
        {
            courses.Sort((x, y) => y.Size.CompareTo(x.Size));
            return courses;
        }

        private static Course CalcForCourse(Course course, Period[] periods, List<Room> rooms, bool isTestRun = false)
        {
            bool isSet = false;
            for (int i = 0; i < periods.Length; i++)
            {
                bool isUnoccupied = CheckWhetherSemesterIsOccupied(periods[i].Elements, course);
                bool lecturerIsOccupied = true;
                if (isUnoccupied)
                {
                    List<SchedulableElement> coursesAtPeriod = periods[i].Elements;
                    if (coursesAtPeriod != null) 
                    {
                        lecturerIsOccupied = CheckWhetherLecturerIsOccupied(coursesAtPeriod, course.Lecturer);
                    } else {
                        coursesAtPeriod = new List<SchedulableElement>();
                    }

                    foreach (Room currentRoom in rooms) 
                    {
                        bool hasRequirements = CheckWhetherEquipmentSuffices(currentRoom, course);

                        if (!currentRoom.Occupied[i] && lecturerIsOccupied && currentRoom.Size >= course.Size && hasRequirements)
                        {
                            if(!isTestRun)
                            {
                                coursesAtPeriod.Add(new SchedulableElement(course, currentRoom));
                                periods[i].Elements = coursesAtPeriod;
                                currentRoom.Occupied[i] = true;
                            }
                            isSet = true;
                            break;
                        }
                    }
                    if (isSet)
                    {
                        break;
                    }
                }
            }
            if (!isSet)
            {
                return course;
            }
            return null;
        }

        private static bool CheckWhetherLecturerIsOccupied(List<SchedulableElement> coursesAtPeriod, Lecturer lecturer)
        {
            for (int k = 0; k < coursesAtPeriod.Count; k++)
            {
                if (coursesAtPeriod[k].Course.Lecturer.Id == lecturer.Id)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool CheckWhetherEquipmentSuffices(Room currentRoom, Course course)
        {
            bool hasRequirements = true;
            for (int l = 0; l < course.Requirements.Count; l++) 
            {
                if (!currentRoom.Equipment.Contains(course.Requirements[l]))
                {
                    hasRequirements = false;
                }
            }

            foreach (Equipment equipment in currentRoom.Equipment)
            {
                if (!course.Requirements.Contains(equipment))
                {
                    hasRequirements = false;
                }
            }
            return hasRequirements;
        }

        private static bool CheckWhetherSemesterIsOccupied(List<SchedulableElement> courseElements, Course course)
        {
            bool isUnoccupied = true;
            if (courseElements != null)
            {
                for (int i = 0; i < courseElements.Count; i++)
                {
                    foreach (Semester semesterAdded in courseElements[i].Course.Semesters)
                    {
                        foreach (Semester semesterToAd in course.Semesters)
                        {
                            if (semesterAdded.Id == semesterToAd.Id)
                            {
                                isUnoccupied = false;
                            }
                        }
                    }
                }
            }
            return isUnoccupied;
        }

        private static void RetryLeftoverCourses(List<Course> leftoverCourses, Period[] periods, List<Room> rooms)
        {
            int iterations = 0;
            for (int i = 0; i < 500; i++)
            {
                if (leftoverCourses.Count == 0)
                {
                    break;
                }

                foreach (Course leftoverCourse in leftoverCourses.ToList())
                {
                    Course stillLeftover = null;
                    foreach (Period period in periods)
                    {
                        stillLeftover = ReadjustLeftoverCourses(period, leftoverCourse, rooms, periods);
                        if (stillLeftover == null)
                        {
                            break;
                        }
                    }
                    
                    iterations++;
                    if (iterations > 10000)
                    {
                        break;
                    }
                }
            }
        }

        private static Course ReadjustLeftoverCourses(Period thisPeriod, Course unsuccessfulCourse, List<Room> rooms, Period[] periods) 
        {
            SchedulableElement blockingCourse = FindBlockingElement(thisPeriod, unsuccessfulCourse);
            if (blockingCourse == null)
            {
                return null;
            }
            Course possiblySetable = CalcForCourse(blockingCourse.Course, periods, rooms, true);

            if (possiblySetable != null)
            {
                bool wasSetable = PutLeftoverCourseOnOldPosition(thisPeriod, blockingCourse, unsuccessfulCourse, rooms);
                if (wasSetable)
                {
                    return CalcForCourse(blockingCourse.Course, periods, rooms);
                }
            } 
            return unsuccessfulCourse;
        }

        private static bool PutLeftoverCourseOnOldPosition(Period period, SchedulableElement blockingCourse, Course unsuccessfulCourse, List<Room> rooms)
        {
            bool wasSetable = false;
            List<SchedulableElement> coursesAtPeriod = period.Elements;
            foreach (SchedulableElement courseElement in period.Elements.ToList())
            {
                if (courseElement.Id == blockingCourse.Id)
                {
                    period.Elements.Remove(blockingCourse);
                    period.RemovedElements.Add(blockingCourse.Id);
                }
                List<Room> freeRooms = GetFreeRoomsAtPeriod(period, rooms);
                bool semesterIsUnoccupied = CheckWhetherSemesterIsOccupied(period.Elements, unsuccessfulCourse);

                bool lecturerIsUnoccupied = CheckWhetherLecturerIsOccupied(coursesAtPeriod, courseElement.Course.Lecturer);
                foreach (Room freeRoom in freeRooms)
                {
                    bool hasRequirements = CheckWhetherEquipmentSuffices(freeRoom, unsuccessfulCourse);

                    if (freeRoom.Size >= unsuccessfulCourse.Size && lecturerIsUnoccupied && hasRequirements && semesterIsUnoccupied)
                    {
                        period.Elements.Add(new SchedulableElement(unsuccessfulCourse, freeRoom));
                        wasSetable = true;
                        break;
                    }
                }
            }
            if (!wasSetable)
            {
                period.Elements.Add(blockingCourse);
            }
            return wasSetable;
        }

        private static SchedulableElement FindBlockingElement(Period period, Course unsuccessfulCourse)
        {
            bool removableElement = false;
            foreach (SchedulableElement selectedCourse in period.Elements)
            {
                foreach (Semester selectedSemester in selectedCourse.Course.Semesters)
                {
                    if (unsuccessfulCourse.Semesters.Exists(x => x.Id == selectedSemester.Id))
                    {
                        removableElement = true;
                        break;
                    }
                }

                if (selectedCourse.Course.Lecturer.Id == unsuccessfulCourse.Lecturer.Id)
                {
                    removableElement = true;
                }

                if (period.RemovedElements != null)
                {
                    if (period.RemovedElements.Exists(x => x == selectedCourse.Id))
                    {
                        removableElement = false;
                    }
                }
                
                if (removableElement)
                {
                    return selectedCourse;
                }
            }
            return null;
        }
        private static List<Room> GetFreeRoomsAtPeriod(Period period, List<Room> allRooms)
        {
            List<Room> freeRooms = GetSortedRooms(allRooms);
            foreach (SchedulableElement course in period.Elements)
            {
                foreach (Room thisRoom in allRooms.ToList())
                {
                    if (course.Room.Name == thisRoom.Name)
                    {
                        freeRooms.Remove(thisRoom);
                    }
                }
            }
            return freeRooms;
        }
    }
}