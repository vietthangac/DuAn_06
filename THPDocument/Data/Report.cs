//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int ReportID { get; set; }
        public string ReportTitle { get; set; }
        public string ReportContent { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public Nullable<int> ReportBy { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
