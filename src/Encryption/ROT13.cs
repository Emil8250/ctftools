using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ctftools.Encryption
{
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
                if (!char.IsLetter(c))
                    return c;

                var rightRot = (char)(c + n);
                var leftRot = (char)(c - n);

                if (char.IsLetter(rightRot) && char.IsLetter(leftRot))
                {
                    return char.IsUpper(c)
                        ? (char.IsUpper(leftRot) ? leftRot : rightRot)
                        : (char.IsLower(leftRot) ? leftRot : rightRot);
                }

                return char.IsLetter(rightRot) ? rightRot : leftRot;
            }));
        }
    }
}

//public static string Rot13(string input) => Regex.Replace(input, "[a-zA-Z]", new MatchEvaluator(c => ((char)(c.Value[0] + (Char.ToLower(c.Value[0]) >= 'n' ? -13 : 13))).ToString()));