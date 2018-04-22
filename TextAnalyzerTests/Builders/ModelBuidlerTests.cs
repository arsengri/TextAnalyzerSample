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
    public class ModelBuidlerTests
    {
        static public IBuilder b;
        [ClassInitialize]
        public static void init(TestContext context)
        {
           b = new ModelBuidler(new RegExParser(), "One String. Two String.");

           b.Build();

        }

        [TestMethod()]
        public void BuiltModelTest()
        {
           
            SourceModel s = b.getModel();

             
            Assert.IsTrue(s.SentenceCount == 2);
            Assert.IsTrue(s.Sentences[0].WordsCount == 2);
            Assert.IsTrue(s.Sentences[0].WordsCount == 2);
        }

        [TestMethod()]
        public void BuiltModelTypeTest()
        {
          
            var s = b.getModel();
            
            Assert.IsTrue(s is SourceModel);
        }
    }
}