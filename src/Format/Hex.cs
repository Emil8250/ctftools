namespace ctftools.Format;
public class Hex
{
    public static int ToInt(string hexValue)
    { 
        return hexValue.Contains("0x") ? Convert.ToInt32(hexValue , 16) : int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);    
    }

    public static string ToText(int intValue)
    {
        return intValue.ToString("X");
    }
}