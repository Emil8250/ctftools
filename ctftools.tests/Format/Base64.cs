using System;
namespace ctftools.tests.Format
{
	public class Base64
	{
        [Theory]
        [InlineData("ZmxhZ3tiYXNlNjR9", "flag{base64}")]
		[InlineData("VGVzdCE=", "Test!")]
		[InlineData("", "")]
		public void ToTextShouldConvertBase64StringToText(string base64, string expected)
		{
            Assert.Equal(expected, ctftools.Format.Base64.ToText(base64));
		}

        [Theory]
        [InlineData("flag{base64}", "ZmxhZ3tiYXNlNjR9")]
		[InlineData("Test!", "VGVzdCE=")]
        [InlineData("", "")]
        public void ToBase64ShouldConvertTextToBase64String(string text, string expected)
		{
			Assert.Equal(expected, ctftools.Format.Base64.ToBase64(text));
		}
	}
}
