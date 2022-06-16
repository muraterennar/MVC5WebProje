//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public int AboutId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int ReviewId { get; set; }
        public int ContactId { get; set; }
        public string NavTitle { get; set; }
        public string FooterText { get; set; }
        public string FooterLinkOne { get; set; }
        public string FooterLinkTwo { get; set; }
    
        public virtual About About { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Course Course { get; set; }
        public virtual Home Home { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
