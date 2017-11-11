using System;
using System.Collections.Generic;
using System.Text;

namespace Roman2Dec
{
    public class Program
    {
        public static string BadInputFormat = "Bad Data: {0}";

        // Call with one or more whitespace separated Roman numeral strings.
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Convert Roman to Decimal values");
                Console.WriteLine("Usage: <roman> [ <roman> ]");
                return;
            }

            if(Convert.ToDecimal(args[0]) == 0)
            {
                Console.WriteLine(BadInputFormat, args[0]);
            }
        }
    }
}
