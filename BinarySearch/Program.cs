using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool backTop = true;
            while (backTop)
            {
                Console.WriteLine("Enter your ascending sorted array of numbers (each element separated by space):");

                List<string> str = Console.ReadLine().Split(' ', (char)StringSplitOptions.RemoveEmptyEntries).ToList();

                bool isDigits = IsDigitsOnly(str);

                if (isDigits == false)
                {
                    Console.WriteLine("Array doesn't contain only digits");
                    continue;
                }

                List<int> arr = str.Select(s => int.Parse(s)).ToList();

                bool isSorted = IsSorted(arr);

                if (isSorted == false)
                {
                    Console.WriteLine("Array is not sorted ascending");
                    continue;
                }

                int n = arr.Count;

                Console.WriteLine("Enter your number for serch:");

                var a = Console.ReadLine();

                int x;

                try
                {
                    x = Convert.ToInt32(a);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{a} is not a number");
                    continue;
                }

                int result = BinarySearch(arr, 0, n - 1, x);
               
                //if (arr[result] != x)
                if (x < arr[0] || x > arr[arr.Count-1] )
                    {
                    Console.WriteLine("Element not present");
                }
                else
                {
                    Console.WriteLine("Element found at " + "index " + result);
                }
                Console.WriteLine("If you want to try again, press 'y'");

                if (Console.ReadLine() != "y")
                {
                    backTop = false;
                }

            }
        }

        private static int BinarySearch(List<int> arr, int l, int r, int x)
        {
            while (l < r)
            {
                int m = (l + r) / 2;
                if (arr[m] < x)
                {
                    l = m + 1;
                }

                else
                    r = m;
            }

            return l;
        }
        private static bool IsSorted(List<int> a)
        {
            for (int i = 0; i < a.Count - 1; i++)
            {
                if (a[i] > a[i + 1])
                    return false;
            }
            return true;
        }
        private static bool IsDigitsOnly(List<string> str)
        {
            foreach (var c in str)
            {

                var a = Int32.TryParse(c, out int res);
                if (a is false)
                    return false;
            }
            return true;
        }
    }
}
