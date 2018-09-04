using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R_Student.Entity
{
    public class UserValidate
    {
        public int User_id { get; set; }
        [Display(Name = "ชื่อผู้ใช้")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [StringLength(15, ErrorMessage = "ชื่อผู้ใช้ เกิน15ตัวอักษร")]
        public string Username { get; set; }

        [Display(Name = "รหัสผ่าน")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ชื่อที่แสดงบนเว็ป")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Name { get; set; }

        [Display(Name = "รูปภาพ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "ระดับผู้ใช้")]
        public Nullable<int> Usertype { get; set; }
    }
    [MetadataType(typeof(UserValidate))]
    public partial class User { }
}