using System;
using System.Linq;
using Roman2Dec;
using Xunit;

namespace Roman2DecTest
{
    public class ConvertTest
    {
        [InlineData("MCM", 1900)]
        [Theory]
        public void TestConvertString(string roman, int equalTo)
        {
            int value = Roman2Dec.Convert.ToDecimal(roman);
            Assert.Equal(value, equalTo);
        }

        [InlineData("M", 1000)]
        [InlineData("D",  500)]
        [InlineData("C",  100)]
        [InlineData("L",   50)]
        [InlineData("X",   10)]
        [InlineData("V",    5)]
        [InlineData("I",    1)]
        [Theory]
        public void TestConvertChar(string character, int equalTo)
        {
            int value = Roman2Dec.Convert.CharacterToDecimal(character);
            Assert.Equal(value, equalTo);
        }
    }
}