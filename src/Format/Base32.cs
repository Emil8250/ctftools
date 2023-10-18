using System;
using System.Text;

namespace ctftools.Format
{
	public class Base32
	{
        // Base32 character set
        private static readonly string Base32CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        // Encode plaintext string to Base32 string
        public static string ToBase32(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            int length = plainTextBytes.Length;
            int encodedLength = (int) Math.Ceiling(length * 8.0 / 5.0);
            int paddingLength = (8 - (encodedLength % 8)) % 8;
            StringBuilder encoded = new(encodedLength + paddingLength);

            int buffer = 0;
            int bufferLength = 0;

            foreach (byte b in plainTextBytes)
            {
                buffer = (buffer << 8) | b;
                bufferLength += 8;

                while (bufferLength >= 5)
                {
                    encoded.Append(Base32CharSet[(buffer >> (bufferLength - 5)) & 0x1F]);
                    bufferLength -= 5;
                }
            }

            if (bufferLength > 0)
            {
                buffer <<= (5 - bufferLength);
                encoded.Append(Base32CharSet[buffer & 0x1F]);
            }

            // Add padding characters
            for (int i = 0; i < paddingLength; i++)
            {
                encoded.Append('=');
            }

            return encoded.ToString();
        }

        // Decode Base32 string to plaintext string
        public static string ToText(string base32Text)
        {
            // Remove whitespace, convert to uppercase
            base32Text = new string(base32Text.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()).ToUpper();
            int textLength = base32Text.Length;

            // Remove padding characters
            base32Text = base32Text.TrimEnd('=');
            int padding = textLength - base32Text.Length;

            // Ensure valid padding
            if (textLength % 8 != 0 ||
                !(padding == 0 || padding == 1 || padding == 3 || padding == 4 || padding == 6))
            {
                throw new ArgumentException("Invalid padding in Base32 string");
            }


            byte[] bytes = new byte[(int) Math.Ceiling(base32Text.Length * 5.0 / 8.0)];

            int buffer = 0;
            int bufferLength = 0;
            int outputIndex = 0;

            foreach (char c in base32Text)
            {
                int value = Array.IndexOf(Base32CharSet.ToArray(), c);
                if (value == -1)
                    throw new ArgumentException("Invalid character in Base32 string");

                buffer = (buffer << 5) | value;
                bufferLength += 5;

                if (bufferLength >= 8)
                {
                    bytes[outputIndex++] = (byte) (buffer >> (bufferLength - 8));
                    bufferLength -= 8;
                }
            }

            return Encoding.UTF8.GetString(bytes, 0, outputIndex);
        }
    }
}
