namespace Q7
{
    using System;

    internal class Program
    {
        static int counter = 0;
        public struct PointStruct { public int x, y; }

        static void Recursion()
        {
            int[] arr = new int[10];
            PointStruct p1, p2, p3, p4;
            PointStruct p5, p6, p7, p8;
            int a, b, c, d;
            counter++;

            Console.WriteLine($"Counter: {counter}");
            Recursion();
        }

        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Starting Stack Overflow test...");
                //קריאה ללא תאי עצירה שתגרום ל overflow
                Recursion();
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"SUCCESS: Stack Overflow occurred.");
            }
        }
    }
}
