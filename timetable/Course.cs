using System.Collections.Generic;
using Newtonsoft.Json;

namespace timetable {
    class Course {
        [JsonConstructor]
        public Course (List<Semester> semester, Lecturer lecturer, string name, int size) 
        {
            this.semesters = semester;
            this.lecturer = lecturer;
            this.name = name;
            this.size = size;
        }

        public Course (Semester semester, Lecturer lecturer, string name) 
        {
            this.semesters.Add(semester);
            this.size += semester.Size;
            this.lecturer = lecturer;
            this.name = name;
        }

        public Course() {}

        private int size = 0;

        public int Size {
            get {
                return size;
            } set {
                size = value;
            }
        }
        private string name;
        public string Name {
            get {
                return name;
            } set {
                name = value;
            }
        }
        private List<Semester> semesters = new List<Semester>();
        public List<Semester> Semesters {
            get {
                return semesters;
            }
            set {
                semesters = value;
            }
        }

        public void SetSemester(Semester semester)
        {
            semesters.Add(semester);
            size += semester.Size;
        }
        private Lecturer lecturer;
        public Lecturer Lecturer {
            get {
                return lecturer;
            } set {
                lecturer = value;
            }
        }

        private List<Equipment> requirements = new List<Equipment>();

        public List<Equipment> Requirements
        {
            get {
                return requirements;
            }
            set {
                requirements = value;
            }
        }

        public override string ToString()
        {
            return name + " " + lecturer.ToString();
        }
    }
}
