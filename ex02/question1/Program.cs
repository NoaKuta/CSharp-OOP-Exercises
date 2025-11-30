using System;
using System.Runtime;
public class program 
    {
    public static void Main()
    {
        Console.WriteLine("--- Testing INT Array Memory Allocation ---");

        // The array sizes to attempt allocating (number of elements)
        long[] sizesToTest = new long[]
        {
            100,                  // Small size (100 elements)
            1_000_000,            // One million elements (~4MB)
            500_000_000,          // Half a billion elements (~2GB)
            2_147_483_648        // Close to the theoretical limit of Int32.MaxValue
        };

        // Size of the int type is 4 bytes
        int sizeOfInt = sizeof(int);

        foreach (long size in sizesToTest)
        {
            // Calculate total required memory in bytes
            long totalMemoryBytes = size * sizeOfInt;

            // Conversion to Gigabytes (for printing purposes only)
            double totalMemoryGB = totalMemoryBytes / 1024.0 / 1024.0 / 1024.0;

            Console.WriteLine($"\n--- Attempting to allocate array of size: {size:N0} elements ---");
            Console.WriteLine($"Total memory required: {totalMemoryBytes:N0} Bytes ({totalMemoryGB:N2} GB)");

            try
            {
                // Attempt to allocate the int array
                int[] myArray = new int[size];

                Console.WriteLine("✅ Array allocation succeeded.");

                // Release memory immediately after successful allocation 
                // to allow larger subsequent attempts.
                myArray = null;
                GC.Collect(); // Request Garbage Collector to free the memory
            }
            // Catch error if insufficient free memory exists on the system
            catch (OutOfMemoryException)
            {
                Console.WriteLine("❌ Allocation FAILED: OutOfMemoryException. Insufficient free RAM/Virtual memory.");
            }
            // Catch error if the size exceeds the Int32.MaxValue limit
            catch (OverflowException)
            {
                Console.WriteLine("❌ Allocation FAILED: OverflowException. Array size exceeds the Int32.MaxValue limit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Allocation FAILED: Unexpected error: {ex.Message}");
            }
        }

        Console.WriteLine("\n--- End of Test ---");
    }
}