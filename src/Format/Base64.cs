using System.Text;

namespace ctftools.Format
{
	public class Base64
	{
		public static string ToText(string base64)
		{
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }

		public static string ToBase64(string text)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
		}
	}
}
