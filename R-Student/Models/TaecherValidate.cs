using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R_Student.Entity
{
    public class TaecherValidate
    {
        [Display(Name = "รหัสอาจารย์")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [StringLength(15, ErrorMessage = "ชื่อผู้ใช้ เกิน11ตัวอักษร")]
        public string Teacher_id { get; set; }

        [Display(Name = "ชื่อผู้ใช้")]
        public Nullable<int> User_id { get; set; }

        [Display(Name = "คำนำหนเาชื่อ")]
        public Nullable<int> Pre_Name { get; set; }

        [Display(Name = "ชื่อ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string FristName { get; set; }

        [Display(Name = "นามสกุล")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string LastName { get; set; }

        [Display(Name = "สาขาวิชา")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Branch { get; set; }

        [Display(Name = "คณะ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Faculty { get; set; }
    }
    [MetadataType(typeof(TaecherValidate))]
    public partial class ProfileTeacher { }
}