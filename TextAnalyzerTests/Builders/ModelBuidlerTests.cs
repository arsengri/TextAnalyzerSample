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
        static public ITextProcessor b;
        [ClassInitialize]
        public static void init(TestContext context)
        {
           b = new TextProcessor(new RegExParser(), "One String. Two String.");

           b.ProcessText();

        }

        [TestMethod()]
        public void BuiltTextModelTest()
        {
           
            ITextModel s = b.GetTextModel();
                         
            Assert.IsTrue(s.Sentences.Count == 2);
            Assert.IsTrue(s.Sentences[0].Words.Count == 2);
            Assert.IsTrue(s.Sentences[0].Words.Count == 2);
        }

        [TestMethod()]
        public void BuiltTextModelTypeTest()
        {
          
            var s = b.GetTextModel(); 
            
            Assert.IsTrue(s is ITextModel);
        }
    }
}