//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvcschoolprjt
{
    using System;
    using System.Collections.Generic;
    
    public partial class student
    {
        public int studentId { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public Nullable<int> ClassId { get; set; }
        public Nullable<int> SubjectID { get; set; }
    
        public virtual Class1 Class1 { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
