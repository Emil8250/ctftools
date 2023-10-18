using System;
namespace ctftools.tests.Format
{
	public class Base32
	{
        [Theory]
        [InlineData("K5\tUG  S5DFON\nYGCY3   FEBUW4ICCMFZ WKMZS", "Whitespace in Base32")]
        [InlineData("JBSWY3DPFQQFO33SNRSCC===", "Hello, World!")]
        [InlineData("MZWGCZ33MJQXGZJTGJ6Q====", "flag{base32}")]
        [InlineData("KrSXg5bRGIzTiNjW", "Test123456")]
        [InlineData("IE======", "A")]
        [InlineData("", "")]
		public void ToTextShouldConvertBase32StringToText(string base32, string expected)
		{
            Assert.Equal(expected, ctftools.Format.Base32.ToText(base32));
		}

        [Theory]
        [InlineData("Hello, World!", "JBSWY3DPFQQFO33SNRSCC===")]
        [InlineData("flag{base32}", "MZWGCZ33MJQXGZJTGJ6Q====")]
        [InlineData("Test123456", "KRSXG5BRGIZTINJW")]
        [InlineData("A", "IE======")]
        [InlineData("", "")]
        public void ToBase32ShouldConvertTextToBase32String(string text, string expected)
		{
			Assert.Equal(expected, ctftools.Format.Base32.ToBase32(text));
		}

        [Theory]
        [InlineData("Hello, Base32 World!")]
        [InlineData("1234")]
        [InlineData("This is a slightly longer string for testing")]
        public void RoundTripEncodingDecoding(string text)
        {
            string encoded = ctftools.Format.Base32.ToBase32(text);
            string decoded = ctftools.Format.Base32.ToText(encoded);
            Assert.Equal(text, decoded);
        }

        [Theory]
        [InlineData("I!======", "Invalid character in Base32 string")]
        [InlineData("MZWGCZ3=3MJQXGZJTGJ6Q===", "Invalid character in Base32 string")]
        [InlineData("IE=====", "Invalid padding in Base32 string")]
        [InlineData("IE====", "Invalid padding in Base32 string")]
        [InlineData("IE===", "Invalid padding in Base32 string")]
        [InlineData("IE==", "Invalid padding in Base32 string")]
        [InlineData("IE=", "Invalid padding in Base32 string")]
        [InlineData("IE", "Invalid padding in Base32 string")]
        public void InvalidBase32StringShouldThrowException(string invalidBase32, string expectedErrorMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => ctftools.Format.Base32.ToText(invalidBase32));
            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }
}
