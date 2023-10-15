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
    }
}