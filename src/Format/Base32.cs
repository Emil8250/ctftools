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
            StringBuilder encoded = new StringBuilder(encodedLength + paddingLength);

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
            base32Text = base32Text.ToUpper();
            int paddingIndex = base32Text.IndexOf('=');
            if (paddingIndex >= 0)
            {
                base32Text = base32Text.Substring(0, paddingIndex); // Remove padding characters
            }

            byte[] bytes = new byte[(int) Math.Ceiling(base32Text.Length * 5.0 / 8.0)];

            int buffer = 0;
            int bufferLength = 0;
            int outputIndex = 0;

            foreach (char c in base32Text)
            {
                if (char.IsWhiteSpace(c))
                    continue;

                int value = Array.IndexOf(Base32CharSet.ToArray(), c);
                if (value == -1)
                    throw new ArgumentException("Invalid character in base32 string");

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
