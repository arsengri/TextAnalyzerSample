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

        [TestMethod()]
        public void BuiltModelTypeTest()
        {
            IBuilder b = new ModelBuidler(new RegExParser(), "One String. Two String");

            b.Build();

            var s = b.getModel();


            Assert.IsTrue(s is SourceModel);
        }

        [TestMethod()]
        public void BuiltModelTest()
        {
            IBuilder b = new ModelBuidler(new RegExParser(), "One String. Two String");

            b.Build();

            SourceModel s = b.getModel();

            
             
            Assert.IsTrue(s.SentenceCount == 2);
            Assert.IsTrue(s.Sentences[0].WordsCount == 2);
            Assert.IsTrue(s.Sentences[0].WordsCount == 2);
        }
    }
}