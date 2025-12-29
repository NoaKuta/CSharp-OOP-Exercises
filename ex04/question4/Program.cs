using System;

public class Fraction
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");
        Numerator = numerator;
        Denominator = denominator;
        Reduce();
    }

    private int GetGCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (a != 0 && b != 0)
        {
            if (a > b)
                a = a % b;
            else
                b = b % a;
        }
        return a | b;

    }

    private void Reduce()
    {
        int gcd = GetGCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }


    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator,
                            f1.Denominator * f2.Denominator);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator,
                            f1.Denominator * f2.Denominator);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        if (f2.Numerator == 0) throw new DivideByZeroException();
        return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
    }

    public static bool operator >(Fraction f1, Fraction f2) => (double)f1.Numerator / f1.Denominator > (double)f2.Numerator / f2.Denominator;
    public static bool operator <(Fraction f1, Fraction f2) => (double)f1.Numerator / f1.Denominator < (double)f2.Numerator / f2.Denominator;

    public static bool operator ==(Fraction f1, Fraction f2) => f1.Numerator == f2.Numerator && f1.Denominator == f2.Denominator;
    public static bool operator !=(Fraction f1, Fraction f2) => !(f1 == f2);

    public override string ToString() => $"{Numerator}/{Denominator}";
}

class Program
{
    static void Main()
    {
        Fraction f1 = new Fraction(8, 12); 
        Fraction f2 = new Fraction(1, 2);

        Console.WriteLine($"Fraction 1: {f1}");
        Console.WriteLine($"Fraction 2: {f2}");

        Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
        Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
        Console.WriteLine($"{f1} > {f2} is {f1 > f2}");
    }
}

