using System;
using System.Linq;

//A Hamming number is a positive integer of the form 2i3j5k, for some non-negative integers i, j, and k.
//    Write a function that computes the nth smallest Hamming number.
//    Specifically:

// The first smallest Hamming number is 1 = 203050
// The second smallest Hamming number is 2 = 213050
// The third smallest Hamming number is 3 = 203150
// The fourth smallest Hamming number is 4 = 223050
// The fifth smallest Hamming number is 5 = 203051
// The 20 smallest Hamming numbers are given in example test fixture.
// Your code should be able to compute all of the smallest 5,000 (Clojure: 2000, NASM: 13282) Hamming numbers without timing out.

public class Hamming
{
    public static long hamming(int n)
    {
        int two = 2, three = 3, five = 5;
        var h = new long[n];
        h[0] = 1;
        long x2 = 2, x3 = 3, x5 = 5;
        int i = 0, j = 0, k = 0;

        for (int index = 1; index < n; index++)
        {
            h[index] = Math.Min(x2, Math.Min(x3, x5));
            if (h[index] == x2) x2 = two * h[++i];
            if (h[index] == x3) x3 = three * h[++j];
            if (h[index] == x5) x5 = five * h[++k];
        }

        return h[n - 1];
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(string.Join(" ", Enumerable.Range(1, 20).ToList().Select(x => hamming(x))));
        Console.WriteLine(hamming(1691));
        Console.WriteLine(hamming(1000000));
    }
}