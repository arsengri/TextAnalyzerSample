using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {

            //string input = "Deberíamos haber hecho más. No lo defiendo, sino que trato de explicarlo.";

            string input = string.Empty;

            if(args == null || args.Length == 0)
            {
                Console.WriteLine("Please etner text:");
                input = Console.ReadLine();
            }
            else
            {
                input = args[0];
            }

            
            ITextParser parser = new RegExParser();

            ITextProcessor textProc = new TextProcessor(parser, input);
			textProc.ProcessText();

            
            Console.WriteLine("JSON:");
            Console.WriteLine(JSONPrinter.Model2Json(textProc.GetJSONModel()));


            /* DB insert */
            Console.WriteLine(Environment.NewLine + "Updating Database... ");

            Data.DataManager dm = new Data.DataManager();

            try
            {
                dm.SaveModelToDB(textProc.GetTextModel());
                Console.WriteLine("Database Updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Update Failed.");
                Console.WriteLine(ex.Message);
                
            }
            
            /* End Of DB Insert*/

            Console.ReadKey();
        }
    }

}
