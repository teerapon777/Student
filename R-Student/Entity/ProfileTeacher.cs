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
    
    public partial class ProfileTeacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProfileTeacher()
        {
            this.Open_Subjects = new HashSet<Open_Subjects>();
        }
    
        public string Teacher_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<int> Pre_Name { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public string Faculty { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Open_Subjects> Open_Subjects { get; set; }
        public virtual PreName PreName { get; set; }
        public virtual User User { get; set; }
    }
}
