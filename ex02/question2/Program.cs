using System;
using System.Diagnostics;

public class Program
{
    // הגדרת גודל המערך הקטן: 10,000,000 איברים  .
    // גודל זה מבטיח שהנתונים נשארים בזיכרון המהיר (Cache/RAM) ולא דורש דפדוף לדיסק.
    const int ARRAY_SIZE = 3000;

    // מספר האיברים אליהם ניגשים בכל בדיקה (1000 ראשונים מול 1000 אחרונים).
    const int ACCESS_COUNT = 1_000;

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testing Array Access Time (Small Array: Head vs Tail) ---");

        // יצירת מערך ה-int
        int[] data = new int[ARRAY_SIZE];

        Console.WriteLine($"Array allocated with {ARRAY_SIZE:N0} elements.");

        // שלב 1: גישה ל-1000 האיברים הראשונים (אינדקס 0)
        long timeStart = MeasureAccessTime(data, 0, ACCESS_COUNT, "Accessing the First 1,000 Elements");

        // שלב 2: גישה ל-1000 האיברים האחרונים
        int lastAccessStart = ARRAY_SIZE - ACCESS_COUNT;
        long timeEnd = MeasureAccessTime(data, lastAccessStart, ACCESS_COUNT, $"Accessing the Last 1,000 Elements (Index {lastAccessStart:N0})");

        Console.WriteLine("\n--- Time Comparison ---");
        Console.WriteLine($"Time to access Head: {timeStart} Ticks");
        Console.WriteLine($"Time to access Tail: {timeEnd} Ticks");

        // חישוב והצגת יחס הזמנים
        double ratio = (double)timeEnd / timeStart;
        Console.WriteLine($"Time Ratio (Tail/Head): {ratio:N2}");
    }

    /// <summary>
    /// מבצע פעולת קריאה לטווח ספציפי במערך ומודד את הזמן שנדרש.
    /// </summary>
    /// <param name="data">המערך שבו יש לגשת.</param>
    /// <param name="startIndex">אינדקס ההתחלה של טווח הגישה.</param>
    /// <param name="count">מספר האיברים לקריאה.</param>
    /// <param name="description">תיאור הבדיקה להדפסה.</param>
    /// <returns>זמן הריצה ביחידות Ticks (דיוק גבוה).</returns>
    private static long MeasureAccessTime(int[] data, int startIndex, int count, string description)
    {
        Console.WriteLine($"\nStarting Test: {description}");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        long sum = 0;

        // קריאה של ערך מכל איבר בטווח
        for (int i = startIndex; i < startIndex + count; i++)
        {
            sum += data[i]; // פעולת קריאה מזיכרון
        }

        stopwatch.Stop();

        // מדפיסים את סכום הדמה כדי למנוע מהמהדר לבטל את הלולאה (אופטימיזציה)
        Console.WriteLine($"Dummy Sum: {sum}");
        return stopwatch.ElapsedTicks;
    }
}