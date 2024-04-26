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
     * Complete the 'runningMedian' function below.
     *
     * The function is expected to return a DOUBLE_ARRAY.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static List<double> runningMedian(List<int> a)
    {
        var medianFinder = new MedianFinder();
        var medianValues = new List<double>(a.Count);
        
        foreach (var item in a)
        {
            medianFinder.AddNum(item);
            medianValues.Add(medianFinder.FindMedian());
        }
        
        return medianValues;
    }

}

class MedianFinder
{
    private readonly PriorityQueue<int, int> _lowers;
    private readonly PriorityQueue<int, int> _highers;

    public MedianFinder()
    {
        _lowers = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x))); // Max heap
        _highers = new PriorityQueue<int, int>(); // Min heap
    }

    public void AddNum(int num)
    {
        _lowers.Enqueue(num, num);

        var minLowers = _lowers.Dequeue();
        _highers.Enqueue(minLowers, minLowers);

        if (_lowers.Count < _highers.Count)
        {
            var minHighers = _highers.Dequeue();
            _lowers.Enqueue(minHighers, minHighers);
        }
    }

    public double FindMedian()
    {
        if (_lowers.Count > _highers.Count)
        {
            return _lowers.Peek();
        }
        else
        {
            return (_lowers.Peek() + _highers.Peek()) / 2.0;
        }
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int aCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = new List<int>();

        for (int i = 0; i < aCount; i++)
        {
            int aItem = Convert.ToInt32(Console.ReadLine().Trim());
            a.Add(aItem);
        }

        List<double> result = Result.runningMedian(a);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
