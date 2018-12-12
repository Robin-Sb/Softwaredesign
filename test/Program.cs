using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = 42;
            var pi = 3.1415f;
            var salute = "Hello, World";
            Console.WriteLine("Type of i:" + i.GetType());
            Console.WriteLine("Type of pi:" + pi.GetType());
            Console.WriteLine("Type of salute:" + salute.GetType());
            Console.WriteLine(i + pi);

        }
    }
}
