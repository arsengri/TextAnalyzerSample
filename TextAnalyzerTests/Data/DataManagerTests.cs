using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Data.Tests
{
    [TestClass()]
    public class DataManagerTests
    {
        static public ITextProcessor b;
        [ClassInitialize]
        public static void init(TestContext context)
        {
            b = new TextProcessor(new RegExParser(), "  ");

            b.ProcessText();

        }
        [TestMethod()]
        [ExpectedException(typeof(ModelNotPopulatedException))]
        public void PreventSavingOfEmptyModelToDBTest()
        {

            DataManager dm = new DataManager();
            dm.SaveModelToDB(b.GetTextModel());
            // Assert.Fail();
        }

       
    }
}