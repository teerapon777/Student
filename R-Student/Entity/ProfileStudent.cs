//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace R_Student.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProfileStudent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfileStudent()
        {
            this.Register_Subjects = new HashSet<Register_Subjects>();
        }
    
        public string Stud_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Pre_Name { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Group_id { get; set; }
        public string Branch { get; set; }
        public string Faculty { get; set; }
    
        public virtual PreName PreName { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Register_Subjects> Register_Subjects { get; set; }
    }
}
