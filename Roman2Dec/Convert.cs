using System;
using System.Collections.Generic;
using System.Text;

namespace Roman2Dec
{
    // Convert Roman to Decimal. Uses Wikipedia definition w/ some extensions:
    // Characters MCDLXVI (not case sensitive)
    // Long character strings (XXXXX=50) allowed
    // Non-adjacent "less" pairs allowed (IC = 99)
    // "Less" is strictly limited to 2 characters: IIX = 8, IXL = 49 NOT allowed.
    // 0 return value -> error (no exceptions or specific error messages.)
    public static class Convert
    {
        public static int ToDecimal(string roman)
        {
            int total = 0;
            int previous = Int32.MaxValue; 
            bool lessEnabled = true;
            foreach (char ch in roman)
            {
                int value = Convert.CharacterToDecimal(ch);
                if(value <= 0)
                {
                    return 0; // bad character
                }

                total += value;
                if (value > previous)
                {
                    // IXL case (IX pair < L)
                    if (!lessEnabled) return 0;
                    lessEnabled = false;

                    // IX -> I + X but should be -I + X
                    total -= 2 * previous;

                    // Sanity
                    if (total <= 0) return 0; 
                }
                else
                {
                    lessEnabled = true;
                }

                previous = value;
            }
            return total;
        }

        public static int CharacterToDecimal(char roman)
        {
            switch (Char.ToUpperInvariant(roman))
            {
                case 'M': return 1000;
                case 'D': return 500;
                case 'C': return 100;
                case 'L': return 50;
                case 'X': return 10;
                case 'V': return 5;
                case 'I': return 1;
            }

            return 0;
        }
    }
}
