using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ctftools.tests.Encryption
{
    public class Binary
    {
        [Theory]
        [InlineData("01100110 01101100 01100001 01100111 01111011 00110001 00110010 00110011 01111101")]
        [InlineData("0110 0110 0110 1100 0110 0001 0110 0111 0111 1011 0011 0001 0011 0010 0011 0011 0111 1101")]
        [InlineData("0 1 1 0 0 1 1 0 0 1 1 0 1 1 0 0 0 1 1 0 0 0 0 1 0 1 1 0 0 11 1 0 1 1 1 1 0 1 1 0 0 1 1 0 0 0 1 0 0 1 1 0 0 1 0 0 0 1 1 0 0 1 1 0 1 1 1 1 1 0 1")]
        public void ToTextShouldConvertBinaryStringToText(string flag)
        {
            flag = flag.Replace(" ", ""); // Remove spaces from the input
            Assert.Equal("flag{123}", ctftools.Format.Binary.ToText(flag));
        }
    }
}
