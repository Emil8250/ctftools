using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.Format;
public class Binary
{
    public static string ToText(string inputBytes)
    {
        var bytes = inputBytes.Split(" ");
        bool addSpace = bytes.Length == 1 && inputBytes.Length != 8;

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < inputBytes.Length; i++)
        {
            if (addSpace && i % 8 == 0)
            {
                result.Append(" ");
            }
            result.Append(inputBytes[i]);
        }

        return string.Concat(result.ToString().Split(" ")
            .Where(bin => !string.IsNullOrEmpty(bin))
            .Select(bin => Convert.ToChar(Convert.ToInt32(bin, 2))));
    }
}
