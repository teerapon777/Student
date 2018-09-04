using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R_Student.Entity
{
    public class SubRegisterValidate
    {

        public int id { get; set; }

        [Display(Name = "รหัสนักศึกษา")]
        public string Stud_id { get; set; }

        [Display(Name = "รหัสวิชา")]
        public Nullable<int> Sub_id { get; set; }

        [Display(Name = "เกรด")]
        public string Grad { get; set; }
    }
    [MetadataType(typeof(SubRegisterValidate))]
    public partial class Register_Subjects { }
}