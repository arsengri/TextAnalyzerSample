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

            //string input = "Deberíamos haber hecho más. No lo defiendo, sino que trato de explicarlo. Asdasd asdasdasd.";

            string input = string.Empty;

            if(args == null || args.Length == 0)
            {
                Console.WriteLine("Please etner text");
                input = Console.ReadLine();
            }
            else
            {
                input = args[0];
            }


           // Console.WriteLine("entered text - >" + input);


            
            ITextParser parser = new RegExParser();

            IBuilder m2 = new ModelBuidler(parser, input);

			m2.Build();


            
            
           Console.WriteLine("JSON:");

            Console.WriteLine(JSONPrinter.Model2Json(m2.getModel()));


            /* DB insert */
            Console.WriteLine(Environment.NewLine + "Updating Database... ");


            Data.DataManager dm = new Data.DataManager();

            try
            {
                dm.SaveModelToDB(m2.getModel());
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
