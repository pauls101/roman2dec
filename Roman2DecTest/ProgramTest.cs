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
            Assert.StartsWith("Convert", result);
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
