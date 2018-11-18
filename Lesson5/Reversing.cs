using System;
using System.Text;

namespace Lesson5 {
    class Reversing {
        public static void ReverseString() 
        {
            Console.WriteLine("Insert some string here");
            String input = Console.ReadLine();
            String output = SplitWords(input);
            output += ReverseLetters(input.ToCharArray()) + "\n";
            Console.WriteLine(output);
        }

        private static string SplitWords(string input) 
        {
            StringBuilder sb = new StringBuilder();
            string[] splittedString = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            ReverseLettersOfWords(splittedString, sb);
            ReverseWords(splittedString, sb);
            return sb.ToString();
        }

        private static void ReverseLettersOfWords(string[] splittedString, StringBuilder sb) 
        {
            for (int i = 0; i < splittedString.Length; i++) {
                sb.Append(ReverseLetters(splittedString[i].ToCharArray())  + " ");
            }
            sb.Append("\n");
        }

        private static void ReverseWords(string[] splittedString, StringBuilder sb) 
        {
            for(int i = splittedString.Length - 1; i > 0; i--) {
                sb.Append(splittedString[i] + " ");
            }
            sb.Append("\n");
        }

        private static string ReverseLetters(char[] input)
        {
            Array.Reverse(input);
            return new string(input);
        }
    }
}