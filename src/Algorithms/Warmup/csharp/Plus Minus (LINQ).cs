using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        var n = arr.Count;

        var numbers = arr.Aggregate(new decimal[3], (acc, val) =>
        {
            if (val > 0) acc[0]++;
            else if (val < 0) acc[1]++;
            else acc[2]++;
            return acc;
        });

        Console.WriteLine("{0:N6}", numbers[0] / n);
        Console.WriteLine("{0:N6}", numbers[1] / n);
        Console.WriteLine("{0:N6}", numbers[2] / n);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
