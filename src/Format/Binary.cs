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
        return string.Concat(inputBytes.Split(" ")
            .Where(bin => !string.IsNullOrEmpty(bin))
            .Select(bin => Convert.ToChar(Convert.ToInt32(bin, 2))));
    }
}
