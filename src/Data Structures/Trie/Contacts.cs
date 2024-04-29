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
     * Complete the 'contacts' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts 2D_STRING_ARRAY queries as parameter.
     */

    public static List<int> contacts(List<List<string>> queries)
    {
        var contacts = new Dictionary<string, int>();
        var result = new List<int>();
        
        foreach (var query in queries)
        {
            var operation = query[0];
            var name = query[1];
            
            if (operation == "add")
            {
                for (var i = 0; i < name.Length; i++)
                {
                    var partialName = name[..(i + 1)];
                    if (contacts.ContainsKey(partialName))
                    {
                        contacts[partialName]++;
                    }
                    else
                    {
                        contacts[partialName] = 1;
                    }
                }
            }
            else if (operation == "find")
            {
                result.Add(contacts.TryGetValue(name, out var value) ? value : 0);
            }
        }
        
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int queriesRows = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> queries = new List<List<string>>();

        for (int i = 0; i < queriesRows; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        List<int> result = Result.contacts(queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
