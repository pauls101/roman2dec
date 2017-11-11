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
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(args);
                Assert.NotEmpty(sw.ToString());
            }
        }
    }
}
