using System;

namespace Lesson10 
{
    delegate void ReportProgressMethod(int progress);
    class Calculator 
    {
        public Calculator () 
        {
            ProgressMethod += delegate(int progress) 
            {
                Console.WriteLine(progress + "%");
            };
            ProgressMethod += EmitPoints;
        }
        public void CalculateSomething () 
        {
            int iterations = 1000;
            int tenthIterations = iterations / 10;
            int addToIterator = tenthIterations;
            int percentage = 10;
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
                    // Console.WriteLine(i.ToString() + " is a prime number.");
                }

                if (i == tenthIterations)
                {
                    ProgressMethod(percentage);
                    tenthIterations += addToIterator;
                    percentage += 10;
                }
            }
        }

        public void EmitPoints(int progress)
        {
            Console.WriteLine(progress);
        }
        public event ReportProgressMethod ProgressMethod;
    }
}