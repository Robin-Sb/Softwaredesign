using System;

namespace timetable 
{
    public class SchedulableElement 
    {
        public SchedulableElement (Course course, Room room)
        {
            this.room = room;
            this.course = course;
            this.id = increment;
            increment++;
        }
        private Room room;
        public Room Room
        {
            get {
                return room;
            }
        }
        private Course course;
        public Course Course 
        {
            get {
                return course;
            }
        }
        private static int increment = 1;
        private int id;
        public int Id 
        {
            get {
                return id;
            } 
        }

    }
}