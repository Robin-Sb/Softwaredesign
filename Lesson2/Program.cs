using System;
using static System.Math;  
namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            // int
            // var i = 42;
            // double
            var pi = 3.1415;
            // string
            var salute = "Hello, World";
            // example float
            var iFloat = 42f;

            // Arrays
            int[] ia = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6, 9};
            int ergebnis = ia[2] * ia[8] + ia[4];
            double[] mathConstants = {Math.PI, Math.E, 2.9E-19}; 

            // Strings 
            string a1 = "Dies ist ";
            string b1 = "ein String";
            string c1 = a1 + b1;

            string a = "eins";
            string b = "zwei";
            string c = "eins";
            bool a_eq_b = (a == b);
            bool a_eq_c = (a == c);

            string meinString = "Dies ist ein String";
            char zeichen = meinString[5];

            // comparison 
            // Console.WriteLine("Input your first number");
            // int input1 = int.Parse(Console.ReadLine());
            // Console.WriteLine("Input your second number");            
            // int input2 = int.Parse(Console.ReadLine());

            // Console.WriteLine(input1 > input2 ? "the first number is bigger than the second" : "the second number is bigger than the first");
            // Console.WriteLine(input1 > 3 && input2 < 6 ? "You won!" : "You lost!");
            // Console.WriteLine("Input a valid number");
            // string i = Console.ReadLine();
            // switch (i)
            // {
            // case "1":
            //     Console.WriteLine("Du hast EINS eingegeben");
            //     break;
            // case "2":
            //     Console.WriteLine("ZWEI war Deine Wahl");
            //     break;
            // case "3":
            //     Console.WriteLine("Du tipptest eine DREI");
            //     break;
            // case "4":
            //     Console.WriteLine("hehe xd");
            //     break;
            // default:
            //     Console.WriteLine("Die Zahl " + i + " kenne ich nicht");
            //     break;
            // }
            // if (i == "1") 
            // {
            //     Console.WriteLine("Du hast EINS eingegeben");

            // } else if (i == "2")
            // {
            //     Console.WriteLine("ZWEI war Deine Wahl");

            // } else if (i == "3")
            // {
            //     Console.WriteLine("Du tipptest eine DREI");
            // } else if (i == "4") 
            // {
            //     Console.WriteLine("hehe xd");
            // } else 
            // {
            //     Console.WriteLine("Die Zahl " + i + " kenne ich nicht");
            // }

            // int i = 1;

            // while (i < 11) 
            // {
            //     Console.WriteLine(i);
            //     i++;
            // }

            string[] someStrings = 
            {
                "Hier",
                "sehen",
                "wir",
                "einen",
                "Array",
                "von",
                "Strings"
            };

            int i = 0;

            // while (i < someStrings.Length)
            // {
            //     Console.WriteLine(someStrings[i]);
            //     i++;
            // }
            for (; i < someStrings.Length; i++)
            {
                Console.WriteLine(someStrings[i]);
            }

            i = 0;
            do 
            {
                Console.WriteLine(someStrings[i]);
                i++;
            }
            while (i < someStrings.Length);

            i = 0;
            while (true)
            {
                Console.WriteLine(someStrings[i]);
                if (i >= someStrings.Length - 1)
                break;
                i++;
            }

            foreach (string s in someStrings)
            {
                Console.WriteLine(s);
            }

            // Console.WriteLine("The type of i is " + i.GetType());
            // Console.WriteLine("The type of pi is " + pi.GetType());
            // Console.WriteLine("The type of salute is " + salute.GetType());
            // Console.WriteLine("The type of iFloat is " + iFloat.GetType());
            // Console.WriteLine(ergebnis);
            // Console.WriteLine("pi: " + mathConstants[0] + ", euler: " + mathConstants[1] + ", kepler: " + mathConstants[2]);
            // Console.WriteLine(ia.Length); 
            // Console.WriteLine("c: " + c1);
            // Console.WriteLine(a_eq_b);
            // Console.WriteLine(a_eq_c);            
            // Console.WriteLine("Das sechste Zeichen von " + meinString + " ist " + zeichen);


            Console.WriteLine();


        }
    }
}
