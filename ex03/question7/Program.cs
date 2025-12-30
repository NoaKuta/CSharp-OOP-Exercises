using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericTableProject
{
    public class OperationTable<T>
    {
        public delegate T OpFunc(T x, T y);

        private List<T> _rowValues;
        private List<T> _colValues;
        private OpFunc _op;

        public OperationTable(List<T> row_values, List<T> col_values, OpFunc _op)
        {
            this._rowValues = row_values;
            this._colValues = col_values;
            this._op = _op;
        }

        public void Print()
        {
            Console.Write("\t");
            foreach (var col in _colValues)
            {
                Console.Write($"{col:F2}\t");
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', (_colValues.Count + 1) * 8));

            foreach (var row in _rowValues)
            {
                Console.Write($"{row:F2} |\t");

                foreach (var col in _colValues)
                {
                    T result = _op(row, col);
                    Console.Write($"{result:F2}\t");
                }

                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<double> row_values = new List<double>();
            for (int i = 1; i <= 4; i++)
            {
                row_values.Add(1.0 / i);
            }

            List<double> col_values = new List<double>();
            for (int i = 1; i <= 4; i++)
            {
                col_values.Add(1.0 / i);
            }

            OperationTable<double> t1 = new OperationTable<double>(
                row_values,
                col_values,
                (x, y) => x + y
            );

            Console.WriteLine("Generic Operation Table (Sum of fractions):");
            t1.Print();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}