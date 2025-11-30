using System;

public class Program
{
    // ----------------------------------------------------------------------
    // א. פונקציית Swap למערך ספציפי (Index-Based Swap)
    // ----------------------------------------------------------------------

    /// <summary>
    /// מחליפה בין שני איברים במערך נתון מסוג int לפי האינדקסים שלהם.
    /// הפונקציה אינה דורשת ref כי מערכים הם Reference Types ב-C# (מועברים כרפרנס).
    /// </summary>
    public static void SwapArrayItems(int[] arr, int indexA, int indexB)
    {
        // בדיקת גבולות בסיסית
        if (indexA < 0 || indexA >= arr.Length || indexB < 0 || indexB >= arr.Length)
        {
            Console.WriteLine("Error: Index out of bounds.");
            return;
        }

        // שימוש במשתנה זמני (temp) לצורך ההחלפה
        int temp = arr[indexA];
        arr[indexA] = arr[indexB];
        arr[indexB] = temp;
    }

    // ----------------------------------------------------------------------
    // ב. פונקציית Swap גנרית (Generic Swap)
    // ----------------------------------------------------------------------

    /// <summary>
    /// מחליפה בין שני משתנים מכל טיפוס שהוא (T).
    /// נדרש שימוש במילת המפתח ref עבור המשתנים.
    /// </summary>
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    // ----------------------------------------------------------------------
    // קוד בדיקה ראשי (Main Method)
    // ----------------------------------------------------------------------

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Question 3: Swap Functions Demonstrations ---");

        // ------------------------------------------------
        // Demonstration A: Index-Based Swap (Array specific)
        // ------------------------------------------------
        Console.WriteLine("\n[A] Testing Index-Based Swap (Specific Array):");
        int[] arrayData = { 10, 20, 30, 40 };
        Console.WriteLine($"Original Array: [ {string.Join(", ", arrayData)} ]");

        SwapArrayItems(arrayData, 0, 3);

        Console.WriteLine($"Array after Swap(0, 3): [ {string.Join(", ", arrayData)} ]"); // Expected: [ 40, 20, 30, 10 ]


        // ------------------------------------------------
        // Demonstration B: Generic Swap (Variables)
        // ------------------------------------------------
        Console.WriteLine("\n[B] Testing Generic Swap (Variables):");
        int x = 50;
        int y = 100;
        string s1 = "Apple";
        string s2 = "Banana";

        Console.WriteLine($"Original Vars: x={x}, y={y}, s1={s1}, s2={s2}");

        // ** נדרש להשתמש במילת המפתח 'ref' **
        Swap<int>(ref x, ref y);
        Swap<string>(ref s1, ref s2);

        Console.WriteLine($"After Swap: x={x}, y={y}, s1={s1}, s2={s2}"); // Expected: x=100, y=50, s1=Banana, s2=Apple


        // ------------------------------------------------
        // Demonstration C: Generic Swap (Array Items)
        // ------------------------------------------------
        Console.WriteLine("\n[C] Testing Generic Swap on Array Items:");
        int[] dataForGeneric = { 5, 6, 7 };
        Console.WriteLine($"Original Array: [ {string.Join(", ", dataForGeneric)} ]");

        // ** ניתן להשתמש ב-ref ישירות על איברי המערך **
        // זהו מענה לשאלה ג'.
        Swap<int>(ref dataForGeneric[0], ref dataForGeneric[2]);

        Console.WriteLine($"Array after Generic Swap(0, 2): [ {string.Join(", ", dataForGeneric)} ]"); // Expected: [ 7, 6, 5 ]
    }
}