//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextAnalyzer.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TextLog
    {
        public TextLog()
        {
            this.Phrases = new HashSet<Phras>();
        }
    
        public int ID { get; set; }
        public string SourceText { get; set; }
    
        public virtual ICollection<Phras> Phrases { get; set; }
    }
}