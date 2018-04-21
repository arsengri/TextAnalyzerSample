using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAnalyzer;

namespace TextAnalyzerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Sentence s = new Sentence();

            Assert.IsTrue(s.WordsCount == 1);
        }
    }
}
