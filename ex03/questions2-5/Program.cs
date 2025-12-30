using System;
using System.Linq;

namespace Question2
{
    public class ArrayProcessor
    {
        public delegate void UnaryAction(double a);

        public static void ProcessArray(double[] array, UnaryAction processor)
        {
            foreach (double item in array)
            {
                processor(item);
            }
        }

        public class SumCalculator
        {
            public double sum { get; private set; } = 0;
            public void AddToSum(double a) { sum += a; }
        }

        public class MaxCalculator
        {
            public double MaxValue { get; private set; } = double.MinValue;
            public void FindMax(double a)
            {
                if (a > MaxValue)
                {
                    MaxValue = a;
                }
            }
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();
            double[] randomArray = Enumerable.Range(0, 10)
                                             .Select(_ => rand.NextDouble())
                                             .ToArray();

            SumCalculator sumCalc = new SumCalculator();
            MaxCalculator maxCalc = new MaxCalculator();

            ProcessArray(randomArray, sumCalc.AddToSum);
            ProcessArray(randomArray, maxCalc.FindMax);

            double lambdaSum = 0;
            double lambdaMax = double.MinValue;

            ProcessArray(randomArray, (val) => lambdaSum += val);
            ProcessArray(randomArray, (val) =>
            {
                if (val > lambdaMax) lambdaMax = val;
            });

            Console.WriteLine($"Sum (Object): {sumCalc.sum}");
            Console.WriteLine($"Max (Object): {maxCalc.MaxValue}");
            Console.WriteLine($"Sum (Lambda): {lambdaSum}");
            Console.WriteLine($"Max (Lambda): {lambdaMax}");
        }
    }
}