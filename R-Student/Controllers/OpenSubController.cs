using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R_Student.Controllers
{
    public class OpenSubController : Controller
    {
        // GET: OpenSub
        public ActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Entity.Open_Subjects model)
        {
            var teacher = (Entity.ProfileTeacher)Session["Teacher"];
            var id = teacher.Teacher_id;
            if (ModelState.IsValid)
            {
                var dal = new DAL.OpensubDAL();
                var chk = dal.ChkSub(model);
                if (chk != null)
                {
                    Response.Write("<script> alert('รหัสวิชานี้ถูกเปิดสอนเเล้ว')</script>");

                }
                else
                {
                    var result = dal.Create(model, id);
                    if (result) if (result) Response.Write("<script> alert('เปิดวิชาเรียนสำเร็จ')</script>");
                    return RedirectToAction("Subject", "RegisterSub");
                }     
            }
            return View(model);
        }

    }
}