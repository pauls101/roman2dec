using System;
using System.IO;
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

        // Convert module finished, do some final end to end tests of the entire program.
        [InlineData("LXiv", 64)]
        [InlineData("mcmxcix", 1999)]
        [InlineData("mdM", 1500)]
        [InlineData("VvIiIiIi", 16)]
        [InlineData("VViviii", 17)]
        [Theory]
        public void TestGoodInput(string roman, int dec)
        {
            string[] args = new string[] { roman };
            string result = RunWithArgs(args);

            Assert.Equal(dec.ToString() + Environment.NewLine, result);
        }

        [InlineData("LXiv", 64, "mcmxcix", 1999)]
        [InlineData("mdM", 1500, "VvIiIiIi", 16)]
        [Theory]
        public void TestGoodInputs(string roman1, int dec1, string roman2, int dec2)
        {
            string[] args = new string[] { roman1, roman2 };
            string result = RunWithArgs(args);

            Assert.Equal(result, string.Format("{0}\r\n{1}\r\n", dec1, dec2));
        }

        [Fact]
        public void TestMixedInputs1()
        {
            // good + bad, look for state mixups
            string good1 = "mcmxcix";
            int goodDec1 = 1999;
            string bad2 = "LXivQ";

            string[] args = new string[] { good1, bad2 };
            string result = RunWithArgs(args);

            string test = string.Format("{0}\r\n", goodDec1) +
                          string.Format(Program.BadInputFormat, bad2) +
                          Environment.NewLine;
            Assert.Equal(result, test);
        }

        [Fact]
        public void TestMixedInputs2()
        {
            // bad + good, look for state mixups
            string bad1 = "LXivQ";
            string good2 = "mcmxcix";
            int goodDec2 = 1999;

            string[] args = new string[] { bad1, good2 };
            string result = RunWithArgs(args);

            string test = string.Format(Program.BadInputFormat, bad1) +
                          string.Format("\r\n{0}\r\n", goodDec2);
            Assert.Equal(result, test);
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
