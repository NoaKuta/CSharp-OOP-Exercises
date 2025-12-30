using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;


namespace Question1
{
    class DelegateExercise
    {
        public delegate double BinaryOperation(double x, double y);

        public static double Add (double x, double y) {  return x + y; }

        public static double Subtract (double x, double y) {return x - y; }

        public static double Multiply (double x , double y) { return x * y; }

        public static double ApplyOperation(BinaryOperation bOp, double a, double b)
        {
            return bOp(a, b);
        }

    }
}