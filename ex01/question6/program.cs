namespace question6
{
    using System;

    // Struct בגודל קטן (למשל 8 בתים)
    public struct SmallStruct
    {
        public long A; // 8 bytes
    }

    // Struct בגודל גדול (למשל 32 בתים)
    public struct LargeStruct
    {
        public long A; // 8 bytes
        public long B; // 8 bytes
        public long C; // 8 bytes
        public long D; // 8 bytes
    }

    // Class קטן - כולל overhead של Object + הפניה
    public class SmallClass
    {
        public int A;
    }

    // Class גדול - כולל overhead של Object + הפניה
    public class LargeClass
    {
        public long A;
        public long B;
        public long C;
        public long D;
    }

    internal class Program
    {
        public static void MemoryAllocationExperiment()
        {
            const int count = 10000;

            // עקוב אחר הקצאה ראשונית
            long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

            int[] intArray = new int[count];
            long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

            double[] doubleArray = new double[count];
            long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

            SmallStruct[] smallStructArray = new SmallStruct[count];
            long afterSmallStructArray = GC.GetAllocatedBytesForCurrentThread();

            LargeStruct[] largeStructArray = new LargeStruct[count];
            long afterLargeStructArray = GC.GetAllocatedBytesForCurrentThread();

            SmallClass[] smallClassArray = new SmallClass[count];
            long afterSmallClassArray = GC.GetAllocatedBytesForCurrentThread();

            // *עבור מערך של class-ים, יש להקצות גם את האובייקטים עצמם כדי לראות את גודלם*
            for (int i = 0; i < count; i++)
            {
                smallClassArray[i] = new SmallClass(); // הקצאת האובייקט ב-Heap
            }
            long afterSmallClassObjects = GC.GetAllocatedBytesForCurrentThread();

            LargeClass[] largeClassArray = new LargeClass[count];
            long afterLargeClassArray = GC.GetAllocatedBytesForCurrentThread();

            for (int i = 0; i < count; i++)
            {
                largeClassArray[i] = new LargeClass(); // הקצאת האובייקט ב-Heap
            }
            long afterLargeClassObjects = GC.GetAllocatedBytesForCurrentThread();

            // פלט: יש לחלק ב-count כדי לקבל גודל פריט בודד (או גודל בסיס)
            Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");

            long intArrayAllocation = afterIntArray - baselineMemory;
            long arrayOverhead = intArrayAllocation - (count * sizeof(int));

            Console.WriteLine("\n--- א. גודל בסיסי של מערך ---");
            Console.WriteLine($"Int Array Allocation (Total): {intArrayAllocation} bytes");
            Console.WriteLine($"Int Array Payload (10000 * 4 bytes): {count * sizeof(int)} bytes");
            Console.WriteLine($"Array Base Overhead (Approx): {arrayOverhead} bytes (כ-24 בתים ב-64bit)");

            Console.WriteLine("\n--- ב. השפעת גודל struct על הזיכרון ---");
            Console.WriteLine($"Small Struct Array Allocation (8 bytes each): {afterSmallStructArray - afterIntArray} bytes");
            Console.WriteLine($"Large Struct Array Allocation (32 bytes each): {afterLargeStructArray - afterSmallStructArray} bytes");
            Console.WriteLine($"מסקנה: ה-struct-ים מאוחסנים ישירות במערך, ולכן גודלם משפיע באופן ישיר ולינארי על גודל המערך הכולל.");

            Console.WriteLine("\n--- ג. השפעת גודל class על הזיכרון ---");
            long smallClassArrayRefAllocation = afterSmallClassArray - afterLargeStructArray;
            Console.WriteLine($"Small Class Array (References only) Allocation: {smallClassArrayRefAllocation} bytes");
            Console.WriteLine($"Small Class Objects (Total): {afterSmallClassObjects - afterSmallClassArray} bytes");

            long largeClassObjectsAllocation = afterLargeClassObjects - afterLargeClassArray;
            Console.WriteLine($"Large Class Array (References only) Allocation: {afterLargeClassArray - afterSmallClassObjects} bytes (דומה לגודל מערך הפניות קטן)");
            Console.WriteLine($"Large Class Objects (Total): {largeClassObjectsAllocation} bytes");

            Console.WriteLine($"מסקנה: הקצאת המערך (Small/LargeClassArray) מקצה רק את מערך ההפניות (בגודל קבוע לכל הפניה). הקצאת האובייקטים בפועל (בתוך הלולאה) היא זו שמוסיפה את גודל האובייקט (כולל Overhead) לזיכרון.");
        }

        static void Main(string[] args)
        {
            MemoryAllocationExperiment();
        }
    }
}
