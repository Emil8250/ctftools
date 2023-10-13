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
            var result = "";
            foreach (var c in input)
            {
                char rightRot = Convert.ToChar(c + n);
                char leftRot = Convert.ToChar(c - n);
                if (!char.IsLetter(c))
                {
                    result += c.ToString();
                    continue;
                }
                if (char.IsLetter(rightRot) && char.IsLetter(leftRot))
                {
                    if (char.IsUpper(c))
                    {
                        if (char.IsUpper(leftRot))
                            result += leftRot;
                        else
                            result += rightRot;
                    }
                    else
                    {
                        if (char.IsLower(leftRot))
                            result += leftRot;
                        else
                            result += rightRot;
                    }
                }
                else
                {
                    if (char.IsLetter(rightRot))
                        result += rightRot;
                    else if (char.IsLetter(leftRot))
                        result += leftRot;
                }

            }
            return result;
        }
    }
}

//public static string Rot13(string input) => Regex.Replace(input, "[a-zA-Z]", new MatchEvaluator(c => ((char)(c.Value[0] + (Char.ToLower(c.Value[0]) >= 'n' ? -13 : 13))).ToString()));