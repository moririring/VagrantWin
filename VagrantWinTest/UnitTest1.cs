using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagrantFileParser;

namespace VagrantWinTest
{
    [TestClass]
    public class VagrantFileParserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sut = new ParserCore();

            sut.Parse("");
        }
    }
}
