//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcademicMarketplace.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PostedBy { get; set; }
        public System.DateTime PostedDate { get; set; }
        public Nullable<int> CompletedBy { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual User CompletedByUser { get; set; }
        public virtual User PostedByUser { get; set; }
    }
}
