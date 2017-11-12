using System;
using System.IO;
using System.Linq;
using Roman2Dec;
using Xunit;

namespace Roman2DecTest
{
    public class ProgramTest
    {
        [Fact]
        public void TestNoInput()
        {
            string[] args = new string[0];
            string result = RunWithArgs(args);
        }

        [Fact]
        public void TestBadInput()
        {
            string badInput = "QQQ";
            string[] args = new string[] { badInput };
            string result = RunWithArgs(args);

            string error = string.Format(Program.BadInputFormat, badInput) + Environment.NewLine;
            Assert.Equal(error, result);
        }

        [Fact]
        public void TestMultipleBadInput()
        {
            string badInput1 = "Q";
            string badInput2 = "R";
            string[] args = new string[] { badInput1, badInput2 };
            string result = RunWithArgs(args);

            string error = string.Format(Program.BadInputFormat, badInput1) + Environment.NewLine + 
                string.Format(Program.BadInputFormat, badInput2) + Environment.NewLine;
            Assert.Equal(error, result);
        }

        [InlineData("LXiv")]
        [InlineData("mcmxcix")]
        [Theory]
        public void TestGoodInput(string value)
        {
            string[] args = new string[] { value };
            string result = RunWithArgs(args);

            Assert.Equal(value + Environment.NewLine, result);
        }

        public string RunWithArgs(string[] args)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(args);
                return sw.ToString();
            }
        }
    }
}
