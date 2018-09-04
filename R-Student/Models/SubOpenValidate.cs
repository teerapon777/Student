using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R_Student.Entity
{
    public class SubOpenValidate
    {
        [Display(Name = "รหัสวิชา")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public int Sub_id { get; set; }

        [Display(Name = "ชื่อวิชา")]
        public string Sub_Name { get; set; }

        [Display(Name = "หน่วยกิต")]
        public Nullable<int> Sub_unit { get; set; }

        [Display(Name = "อาจารย์ผู้สอน")]
        public string Teacher_id { get; set; }
    }
    [MetadataType(typeof(SubOpenValidate))]
    public partial class Open_Subjects { }
}