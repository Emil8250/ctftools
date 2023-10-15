using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.tests.Format
{
    public class Binary
    {
        [Theory]
        [InlineData("01100110 01101100 01100001 01100111 01111011 00110001 00110010 00110011 01111101")]
        [InlineData("011001100110110001100001011001110111101100110001001100100011001101111101")]
        public void ToTextShouldConvertBinaryStringToText(string flag)
        {
            Assert.Equal("flag{123}", ctftools.Format.Binary.ToText(flag));
        }
    }
}