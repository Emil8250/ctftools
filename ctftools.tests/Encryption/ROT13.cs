using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctftools.tests.Encryption
{
    public class ROT13
    {
        [Fact]
        public void RotateShouldReturnRotatedString()
        {
            Assert.Equal("Th1sIzFlag{f14g}", ctftools.Encryption.ROT13.Rotate("Gu1fVmSynt{s14t}"));
        }
    }
}