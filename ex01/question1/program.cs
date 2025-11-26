namespace question1
{
    public class PointClass
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y}) (Class)";
    }

    public struct PointStruct
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y}) (Struct)";
    }
    internal class Program
    {
        static void AssignmentDemo()
        {

            PointClass pc1 = new PointClass { X = 10, Y = 20 };
            PointClass pc2 = pc1; 
            Console.WriteLine($"לפני שינוי: pc1={pc1}, pc2={pc2}");

            pc2.X = 99; 
            Console.WriteLine($"אחרי שינוי pc2: pc1={pc1}, pc2={pc2}");


            Console.WriteLine();

            PointStruct ps1 = new PointStruct { X = 100, Y = 200 };
            PointStruct ps2 = ps1; //  (Deep Copy)
            Console.WriteLine($"לפני שינוי: ps1={ps1}, ps2={ps2}");

            ps2.X = 999; 
            Console.WriteLine($"אחרי שינוי ps2: ps1={ps1}, ps2={ps2}");

        }

        static void ChangeClass(PointClass p)
        {
            p.X = 500; 
        }

        static void ChangeStruct(PointStruct p)
        {
            p.X = 5000;
        }

        static void FunctionCallDemo()
        {

            // Class
            PointClass pc = new PointClass { X = 1, Y = 2 };
            Console.WriteLine($"לפני פונקציה (Class): {pc}");
            ChangeClass(pc);
            Console.WriteLine($"אחרי פונקציה (Class): {pc}");

            Console.WriteLine();

            // Struct
            PointStruct ps = new PointStruct { X = 11, Y = 22 };
            Console.WriteLine($"לפני פונקציה (Struct): {ps}");
            ChangeStruct(ps);
            Console.WriteLine($"אחרי פונקציה (Struct): {ps}");
        }

        // ב. שינוי Struct בתוך פונקציה באמצעות ref
        static void ChangeStructByRef(ref PointStruct p)
        {
  
            p.X = 888;
        }

        static void StructByRefDemo()
        {
            Console.WriteLine("\n--- 1.ב: שינוי Struct באמצעות ref ---");

            PointStruct ps = new PointStruct { X = 33, Y = 44 };
            Console.WriteLine($"לפני פונקציה (Struct עם ref): {ps}");

            ChangeStructByRef(ref ps);
            Console.WriteLine($"אחרי פונקציה (Struct עם ref): {ps}");
            Console.WriteLine("Struct עם ref: העברה היא **Reference-by** מאולץ, השינוי נשמר.");
        }

        static void Main(string[] args)
        {
            AssignmentDemo();
            FunctionCallDemo();
            StructByRefDemo();
        }
    }
}
