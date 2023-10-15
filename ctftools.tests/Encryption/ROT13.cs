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
        public void RotateShouldReturnRotatedStringBy13()
        {
            Assert.Equal("Th1sIzFlag{f14g}", ctftools.Encryption.ROT13.Rotate("Gu1fVmSynt{s14t}"));
        }

        [Fact]
        public void RotateShouldReturnRotatedStringByN()
        {
            Assert.Equal("Th1sIzFlag{f14g}", ctftools.Encryption.ROT13.Rotate("Dr1cSjPvkq{p14q}", 16));
        }

        [Fact]
        public void RotateShouldReturnRotatedStringIncludingNumbersBy13()
        {
            Assert.Equal("Th1sIzFlag{f14g}", ctftools.Encryption.ROT13.Rotate("Gu8fVmSynt{s81t}", true));
        }

        [Fact]
        public void RotateShouldReturnRotatedStringIncludingNumbersByN()
        {
            Assert.Equal("Th1sIzFlag{f14g}", ctftools.Encryption.ROT13.Rotate("Dr5cSjPvkq{p58q}", true, 16));
        }
    }
}