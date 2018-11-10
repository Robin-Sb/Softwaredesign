using System;
namespace Lesson4 {
    public class Person
    {
        public Person (String firstName, String lastName, DateTime age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        public string firstName;
        public string lastName;
        public DateTime age;

        public override string ToString() { 
            return firstName + " " + lastName;
        }

    }
}
