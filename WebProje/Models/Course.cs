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
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Category = new HashSet<Category>();
        }
    
        public int Id { get; set; }
        public string CourseCategoryName { get; set; }
        public string CourseFirstTitle { get; set; }
        public string CourseLastTitle { get; set; }
        public string CourseImage { get; set; }
        public string CourseText { get; set; }
        public string CourseButtonTitle { get; set; }
        public string CourseName { get; set; }
        public string CourseLink { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Category { get; set; }
    }
}
