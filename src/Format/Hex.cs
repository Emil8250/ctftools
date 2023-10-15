using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.Format;
public class Hex
{
    public static int ToInt(string hexValue)
    { 
        return hexValue.Contains("0x") ? Convert.ToInt32(hexValue , 16) : int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);    
    }
}