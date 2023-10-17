using System;
namespace ctftools.tests.Format
{
	public class Base32
	{
        [Theory]
        [InlineData("MZWGCZ33MJQXGZJTGJ6Q====", "flag{base32}")]
        [InlineData("KRSXG5BRGIZTINJW", "Test123456")]
        [InlineData("", "")]
		public void ToTextShouldConvertBase32StringToText(string base32, string expected)
		{
            Assert.Equal(expected, ctftools.Format.Base32.ToText(base32));
		}

        [Theory]
        [InlineData("flag{base32}", "MZWGCZ33MJQXGZJTGJ6Q====")]
        [InlineData("Test123456", "KRSXG5BRGIZTINJW")]
        [InlineData("", "")]
        public void ToBase32ShouldConvertTextToBase32String(string text, string expected)
		{
			Assert.Equal(expected, ctftools.Format.Base32.ToBase32(text));
		}
	}
}
