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
    
    public partial class Phras
    {
        public Phras()
        {
            this.PhraseWords = new HashSet<PhraseWord>();
        }
    
        public int ID { get; set; }
        public int LogID { get; set; }
        public string Phrase { get; set; }
        public Nullable<int> SeqNo { get; set; }
    
        public virtual TextLog TextLog { get; set; }
        public virtual ICollection<PhraseWord> PhraseWords { get; set; }
    }
}
