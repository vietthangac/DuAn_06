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
    
    public partial class Guestbook
    {
        public int GuestbookID { get; set; }
        public string ChatContent { get; set; }
        public Nullable<System.DateTime> ChatTime { get; set; }
        public Nullable<int> ChatName { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
