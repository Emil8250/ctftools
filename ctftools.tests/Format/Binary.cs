using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.tests.Encryption
{
    public class Binary
    {
        [Fact]
        public void ToTextShouldConvertBinaryStringToText()
        {
            var flag = "01100110 01101100 01100001 01100111 01111011 00110001 00110010 00110011 01111101";
            Assert.Equal("flag{123}", ctftools.Format.Binary.ToText(flag));
        }
    }
}