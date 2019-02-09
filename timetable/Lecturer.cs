using Newtonsoft.Json;

namespace timetable {
    public class Lecturer {
        [JsonConstructor]
        public Lecturer (string firstName, string lastName, int id) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = firstName + " " + lastName;
            this.id = id;
        }

        public Lecturer (string firstName, string lastName) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = firstName + " " + lastName;
            this.id = increment;
            increment++;
        }
        private string firstName;
        public string FirstName 
        {
            get {
                return firstName;
            }
        }
        private static int increment = 1;
        private int id;
        public int Id 
        {
            get {
                return id;
            } set {
                id = value;
            }
        }
        
        private string lastName;
        public string LastName 
        {
            get {
                return lastName;
            }
        }
        private string fullName;
        public string FullName
        {
            get {
                return fullName;
            }
        }

        public override string ToString()
        {
            return fullName;
        }
    }
}
