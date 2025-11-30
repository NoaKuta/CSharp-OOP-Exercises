using System;
using System.Diagnostics;
using System.Threading.Tasks; // נדרש עבור הפעלת תהליכונים (Tasks)

public class Program
{
    // גודל המערך (50 מיליון איברים = כ-200 MB).
    // זה מבטיח שהנתונים ב-RAM וחורגים מה-Cache.
    const int ARRAY_SIZE = 50_000_000;

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Multithreaded Array Access Test ---");

        // --- ניסוי א: גישה לאיזורים שונים (Disjoint Access) ---
        long timeDisjoint = TestAccessMode(false);
        Console.WriteLine($"\n[Result A] Disjoint Access Time: {timeDisjoint} ms");

        // --- ניסוי ב: גישה לכל המערך (Shared Access) ---
        long timeShared = TestAccessMode(true);
        Console.WriteLine($"\n[Result B] Shared Access Time: {timeShared} ms");

        Console.WriteLine("\n--- Comparison Summary ---");
        Console.WriteLine($"Disjoint Access was {(double)timeShared / timeDisjoint:N2} times faster/slower than Shared Access.");
    }

    private static long TestAccessMode(bool sharedAccess)
    {
        // יוצרים מערך חדש ומאפסים את כל האיברים
        int[] data = new int[ARRAY_SIZE];
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine($"\nStarting Test (Shared Access: {sharedAccess})");
        stopwatch.Start();

        // הגדרת טווחי הגישה לכל תהליכון:
        int halfSize = ARRAY_SIZE / 2;

        // Thread 1: מטפל בחלק הראשון / המלא
        Task t1 = Task.Run(() =>
        {
            int end = sharedAccess ? ARRAY_SIZE : halfSize;
            for (int i = 0; i < end; i++)
            {
                // מבצעים כתיבה (Increment)
                data[i]++;
            }
        });

        // Thread 2: מטפל בחלק השני / המלא
        Task t2 = Task.Run(() =>
        {
            // אם הגישה משותפת (true), שניהם מתחילים מ-0.
            // אם הגישה נפרדת (false), Thread 2 מתחיל מהאמצע.
            int start = sharedAccess ? 0 : halfSize;
            for (int i = start; i < ARRAY_SIZE; i++)
            {
                // מבצעים כתיבה (Increment)
                data[i]++;
            }
        });

        // מחכים ששני התהליכונים יסיימו את העבודה
        Task.WaitAll(t1, t2);

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
