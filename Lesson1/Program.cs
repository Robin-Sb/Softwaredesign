using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                int argsAsInt = Int32.Parse(args[0]);
                if (argsAsInt > 0 && argsAsInt < 1000) {
                    Console.WriteLine(RomanConversion.GetRomanNumber(argsAsInt));
                } else {
                    Console.WriteLine("Only numbers from 1 to 999 can be converted.");
                }
            } catch {
                Console.WriteLine("Unable to parse the string into an integer. Is your argument really a number?");
            } 
        }
    }
}
