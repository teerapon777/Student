using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace R_Student.Models
{
    public class Login
    {
        [Display(Name = "ชื่อผู้ใช้")]
        [Required(ErrorMessage = "กรณากรอก Username")]
        public string Username { get; set; }
        [Display(Name = "รหัสผ่าน")]
        [Required(ErrorMessage = "กรณากรอก Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}