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
    
    public partial class PhraseWord
    {
        public int PhraseID { get; set; }
        public int WordID { get; set; }
        public Nullable<int> SeqNo { get; set; }
    
        public virtual Phras Phras { get; set; }
        public virtual Word Word { get; set; }
    }
}
