namespace ctftools.tests.Format
{
    public class Hex
    {
        [Theory]
        [InlineData("ff", 255)]
        [InlineData("0xFF", 255)]
        [InlineData("20F", 527)]
        public void ToIntShouldConvertHexToIntReturnsIntSuccess(string hexValue, int expected) 
        {
            Assert.Equal(expected, ctftools.Format.Hex.ToInt(hexValue));
        }

        [Theory]
        [InlineData("ff", 88)]
        [InlineData("0xFF", 123124)]
        [InlineData("20F", 55)]
        public void ToIntShouldConvertHexToIntReturnsIntFail(string hexValue, int expected) 
        {
            Assert.NotEqual(expected, ctftools.Format.Hex.ToInt(hexValue));
        }

        [Fact]
        public void ToIntShouldConvertHexToIntReturnsIntThrowsOverflowFormatException() 
        {
            Assert.Throws<FormatException>(() => ctftools.Format.Hex.ToInt("Hej"));
        }

        [Theory]
        [InlineData(255, "FF")]
        [InlineData(527, "20F")]
        public void ToTextShouldConertIntToHexReturnsStringSuccess(int intValue, string expected) 
        {
            Assert.Equal(expected, ctftools.Format.Hex.ToText(intValue));
        }

        [Theory]
        [InlineData(255, "F2")]
        [InlineData(527, "22")]
        public void ToTextShouldConertIntToHexReturnsStringFail(int intValue, string expected) 
        {
            Assert.NotEqual(expected, ctftools.Format.Hex.ToText(intValue));
        }
    }
}