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
        
		public static string Model2Json(IJSONModel model)
		{
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
			return json;
		}
    }
}
