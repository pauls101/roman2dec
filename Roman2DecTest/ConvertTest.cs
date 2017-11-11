using System;
using System.Linq;
using Roman2Dec;
using Xunit;

namespace Roman2DecTest
{
    public class ConvertTest
    {
        [InlineData ("MCM", 1900)]
        [Theory]
        public void TestConvertString(string roman, int equalTo)
        {
            int value = Roman2Dec.Convert.ToDecimal(roman);
            Assert.Equal(value, equalTo);
        }
    }
}