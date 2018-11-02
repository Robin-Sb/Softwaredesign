using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Console.WriteLine("From which system do you want to convert?");
                int fromSystem = int.Parse(Console.ReadLine());
                Console.WriteLine("To which system do you want to convert?");
                int toSystem = int.Parse(Console.ReadLine());

                if (fromSystem == 10 || toSystem == 10) 
                {
                Console.WriteLine("Which number do you want to convert?");
                int number = int.Parse(Console.ReadLine());
                    Console.WriteLine(ConvertNumberFromSystemToSystem(number, fromSystem, toSystem));
                } else 
                {
                    Console.WriteLine("Either of the systems must be 10.");
                }
            } catch 
            {
                Console.WriteLine("Can't parse your inputs. Are those really numbers?");
            }
        }

        static int ConvertNumberFromSystemToSystem(int number, int fromSystem, int toSystem)
        {
            int result = 0;
            result = OtherToDecimal(number, fromSystem);
            result = DecimalToOther(result, toSystem);
            return result;
        }

        static int DecimalToOther(int dec, int system)
        {
            int result = 0;
            int factor = 1;
            while (dec != 0)
            {
                int digit = dec % system;
                dec /= system;
                result += factor * digit;
                factor *= 10;
            }
            return result;
        }

        static int OtherToDecimal(int other, int system)
        {
            int result = 0;
            int factor = 1;
            while (other != 0)
            {
                int digit = other % 10;
                other /= 10;
                result += factor * digit;
                factor *= system;
            }
            return result;
        }
    }

}
