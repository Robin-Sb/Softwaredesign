using System;
using System.Collections.Generic;

namespace timetable 
{
    public class Semester 
    {
        public Semester (string major, int grade, int size, int id) {
            this.major = major;
            this.grade = grade;
            this.size = size;
            this.id = id;
        }
        private string major;
        public string Major 
        {
            get {
                return major;
            }
        }

        private int id;
        public int Id 
        {
            get {
                return id;
            }
            set {
                id = value;
            }
        }
        private int grade;
        public int Grade 
        {
            get {
                return grade;
            }
            set {
                grade = value;
            }
        }
        private int size;
        public int Size {
            get {
                return size;
            }
        }

        public override string ToString()
        {
            return major + grade.ToString();
        }
    }
}