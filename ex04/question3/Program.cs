using System;
using System.Collections.Generic;

public class OperationTable<T>
{
    public delegate T OpFunc(T x, T y);

    public OpFunc op;

    private List<T> rowValues;
    private List<T> colValues;
    private T[,] table; 

    public OperationTable(List<T> _row_values, List<T> _col_values, OpFunc _op)
    {
        this.rowValues = _row_values;
        this.colValues = _col_values;
        this.op = _op;

        table = new T[rowValues.Count, colValues.Count];

        for (int i = 0; i < rowValues.Count; i++)
        {
            for (int j = 0; j < colValues.Count; j++)
            {
                table[i, j] = op(rowValues[i], colValues[j]);
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < rowValues.Count; i++)
        {
            for (int j = 0; j < colValues.Count; j++)
            {
                Console.Write(table[i, j] + "\t");
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
        for (int i = 1; i < 5; i++)
        {
            col_values.Add(1.0 / i);
        }

        OperationTable<double> t1 = new OperationTable<double>(row_values, col_values, (x, y) => x + y);

        t1.Print();
    }
}