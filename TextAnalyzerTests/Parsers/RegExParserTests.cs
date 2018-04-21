using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Tests
{
    [TestClass()]
    public class RegExParserTests
    {

       static RegExParser parser;


        [ClassInitialize]
        public static void init(TestContext context)
        {
             parser = new RegExParser();   

        }

        [TestMethod()]
        public void GetSentencesListTest()
        {
          

            var list = parser.GetSentencesList("One Phrase. Second Phrase");

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod()]
        public void GetWordsListTest()
        {
            RegExParser parser = new RegExParser();

            var list = parser.GetWordsList("One Phrase.");


            Assert.AreEqual(2, list.Count);
        }


      
    }
}