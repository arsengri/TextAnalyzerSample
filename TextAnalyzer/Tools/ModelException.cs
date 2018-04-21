using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Tools
{
    
    class ModelNotPopulatedException : Exception
    {
        public ModelNotPopulatedException()
        {

        }

        public ModelNotPopulatedException(string name)
            : base(String.Format("Model is not populated. Model Object Name: {0}", name))
        {

        }

    }
}
