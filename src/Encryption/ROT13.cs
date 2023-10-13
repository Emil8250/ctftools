using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ctftools.Encryption;

public class ROT13
{
    /// <summary>
    /// A simple cipher that rotates letters by 13.
    /// </summary>
    /// <param name="input">The string input which needs to be rotated</param>
    /// <param name="n">The amount of spaces to rotate</param>
    /// <returns></returns>
    public static string Rotate(string input, int n = 13)
    {
        return string.Concat(input.Select(c =>
        {
            if (!char.IsLetter(c)) return c;
            var baseChar = char.IsUpper(c) ? 'A' : 'a';
            return (char)(baseChar + (c - baseChar + n) % 26);

        }));
    }
}