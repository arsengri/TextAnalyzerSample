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
        static public IBuilder b;
        [ClassInitialize]
        public static void init(TestContext context)
        {
            b = new ModelBuidler(new RegExParser(), "  ");

            b.Build();

        }
        [TestMethod()]
        [ExpectedException(typeof(ModelNotPopulatedException))]
        public void SaveEmptyModelToDBTest()
        {

            DataManager dm = new DataManager();
            dm.SaveModelToDB(b.getModel());
            // Assert.Fail();
        }

       
    }
}