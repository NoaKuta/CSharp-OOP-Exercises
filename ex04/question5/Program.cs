using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        List<Fraction> fractions = new List<Fraction>();
        for (int i = 1; i <= 12; i++)
        {
            fractions.Add(new Fraction(i, 12));
        }

      
        OperationTable<Fraction> table = new OperationTable<Fraction>(
            fractions,
            fractions,
            (x, y) => x + y
        );

        Console.WriteLine("Addition Table for Fractions (1/12 to 12/12):");
        Console.WriteLine("-----------------------------------------------");
        table.Print();
    }
}