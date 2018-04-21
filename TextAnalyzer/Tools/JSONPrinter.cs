using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace TextAnalyzer
{
    class JSONPrinter
    {
        public static string PrintOut(Object model)
        {
            var json = new JavaScriptSerializer().Serialize(model);
            return json;
        }

		public static string Model2Json(Object model)
		{
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
			return json;
		}
    }
}
