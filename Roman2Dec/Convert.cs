﻿using System;
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
            foreach (char ch in roman)
            {
                int value = Convert.CharacterToDecimal(ch);
                if(value > 0)
                {
                    total += value;
                }
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
