using System;

namespace Lesson10 
{
    delegate void ReportProgressMethod(int progress);
    class Calculator 
    {
        public static void CalculateSomething () 
        {
            Calculator calc = new Calculator();
            ReportProgressMethod progressReporter = new ReportProgressMethod(calc.ProgressMethod);
            int iterations = 1000;
            int tenthIterations = iterations / 10;
            int percentage = 0;
            bool isDividable;
            for (int i = 0; i < iterations; i++) 
            {
                isDividable = false;
                for (int j = 2; j < i - 1; j++)
                {
                    if (i % j == 0)
                    {
                        isDividable = true;
                    }
                }

                if (!isDividable)
                {
                    Console.WriteLine(i.ToString() + " is a prime number.");
                }

                if (i == tenthIterations)
                {
                    progressReporter(percentage);
                    tenthIterations += tenthIterations;
                    percentage += 10;
                }
            }
        }
        public event ReportProgressMethod ProgressMethod;
    }
}