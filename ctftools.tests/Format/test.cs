using System;
using Xunit;

namespace ctftools.tests.Encryption.Tests
{
    public class BinaryTests
    {
        [Theory]
        [InlineData("01100110 01101100 01100001 01100111 01111011 00110001 00110010 00110011 01111101", "flag{123}")]
        [InlineData("0110 0110 0110 1100 0110 0001 0110 0111 0111 1011 0011 0001 0011 0010 0011 0011 0111 1101", "flag{123}")]
        [InlineData("0 1 1 0 0 1 1 0 0 1 1 0 1 1 0 0 0 1 1 0 0 0 0 1 0 1 1 0 0 11 1 0 1 1 1 1 0 1 1 0 0 1 1 0 0 0 1 0 0 1 1 0 0 1 0 0 0 1 1 0 0 1 1 0 1 1 1 1 1 0 1", "flag{123}")]
        public void ToTextShouldConvertBinaryStringToText(string inputBinary, string expectedText)
        {
            // Remove spaces from the input binary
            inputBinary = inputBinary.Replace(" ", "");

            Assert.Equal(expectedText, ctftools.Format.Binary.ToText(inputBinary));
        }
    }
}
