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
            return 0;
        }
    }
}
