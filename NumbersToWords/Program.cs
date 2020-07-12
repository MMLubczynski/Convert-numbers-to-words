using System;
using System.Text.RegularExpressions;
using static System.Console;


namespace NumbersToWords
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunApplication();
        }

        private static void RunApplication()
        {
            ConsoleKeyInfo cki;
            var transform = new Transform();
            string result = String.Empty;
            string stringValue = String.Empty;

            Write("This application converts numbers into words.");
            do
            {
                Write("Please Enter a number without decimals: ");
                stringValue = ReadLine();
                if (Regex.IsMatch(stringValue, @"^\d+$"))
                {
                    result = transform.ToWords(stringValue);
                    WriteLine($"Result: {result}");
                }
                else
                    WriteLine("Please enter only numeric values.");
                WriteLine("Please press <Enter> to continue or <Q> to exit...");
                cki = ReadKey();
            } while (cki.Key != ConsoleKey.Q);
        }
    }
}