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
     * Complete the 'isBalanced' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isBalanced(string s)
    {
        var brackets = new Stack<char>();
        
        foreach (var ch in s)
        {
            if (ch is '(' or '[' or '{')
            {
                brackets.Push(ch);
            }
            else
            {
                if (brackets.Count == 0)
                {
                    return "NO";
                }
                
                var bracket = brackets.Pop();
                
                var isRoundBracketBalanced = ch == ')' && bracket == '(';
                var isSquareBracketBalanced = ch == ']' && bracket == '[';
                var isBracketBalanced = ch == '}' && bracket == '{';
                var isBalanced = isRoundBracketBalanced || isSquareBracketBalanced || isBracketBalanced;
                
                if (!isBalanced)
                {
                    return "NO";
                }
            }
        }
        
        return brackets.Count == 0 ? "YES" : "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = Result.isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
