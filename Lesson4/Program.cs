using System;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person robin = new Person("Robin", "Schwab", new DateTime(1997, 09, 08));
            Person niko = new Person("Nikola", "Hack", new DateTime(2001, 03, 23));
            Person tomi = new Person("Tomislav", "Sever", new DateTime(1996, 12, 23));
            Person jonny = new Person("Jon", "Doe", new DateTime(1945, 01, 25));
            Person infant = new Person("Infant", "Ino", new DateTime(2017, 05, 03));
            Person[] array  = new Person[] {robin, niko, tomi, jonny, infant};

            var today = DateTime.Today;
            for(int i = 0; i < array.Length; i++) {
                var age = today.Year - array[i].age.Year;
                if (array[i].age > today.AddYears(-age)) age--;

                if (age > 20) {
                    Console.WriteLine(array[i].ToString());
                }
            }
        }
    }
}
