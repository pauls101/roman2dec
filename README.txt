# roman2dec

Very simple command line Roman numeral to decimal converter for Windows, written in C# for speed and minimum typing. 
Enter one or more space separated numbers in Roman format, get the converted values or "Bad data" back. 

Very basic implementation: everything static, no .NET advanced features. Done to demo TDD for a simple project.

- No detailed error messages for parse failures, etc.
- Based on https://en.wikipedia.org/wiki/Roman_numerals with some extensions
    - Character set MCDLXVI (not case sensitive)
    - Long character strings (XXXXX=50) allowed
    - Non-adjacent "less" pairs allowed (IC = 99)
    - "Less" syntax is strictly limited to 2 character pairs: IIX = 8, IXL = 49, XXIXX NOT allowed.
    - Any failure results in "Bad Data NNN"; no detailed info for parse errors, etc.
