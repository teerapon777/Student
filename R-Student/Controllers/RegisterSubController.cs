using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R_Student.Controllers
{
    public class RegisterSubController : Controller
    {
        // GET: RegisterSub

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Entity.Register_Subjects model)
        {
            var user = (Entity.ProfileStudent)Session["Stud"];
            var Stud = user.Stud_id;
            if (ModelState.IsValid)
            {
                var dal = new DAL.RegisterSubDAL();
                var chk = dal.ChkSub(model);
                if (chk != null)
                {
                    Response.Write("<script> alert('รหัสวิชานี้นักศึกษาลงทะเบียนไว้เเล้ว')</script>");

                }
                else
                {
                    var result = dal.Create(model, Stud);
                    if (result) Response.Write("<script> alert('ลงทะเบียนสำเร็จ')</script>");
                    return RedirectToAction("index", "User");
                }
                return View();

            }
            return View(model);
        }

        public ActionResult Classroom(int subid)
        {
            var model = (Entity.ProfileTeacher)Session["Teacher"];
            string id = model.Teacher_id;
            var dal = new DAL.RegisterSubDAL();
            var Sub = dal.SubGradList();
            Sub = Sub.Where(a => a.Open_Subjects.Teacher_id == id && a.Sub_id == subid).ToList();
            return View(Sub);
        }

        public ActionResult EditGrad(int id)
        {
            using (var db = new Entity.Entities())
            {
                ViewBag.PreName = db.PreName.ToList();
            }
            var dal = new DAL.RegisterSubDAL();
            var teacher = dal.Searchgrad(id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult EditGrad(Entity.Register_Subjects model, int id)
        {
            try
            {
                var dal = new DAL.RegisterSubDAL();
                var grad = dal.Searchgrad(id);
                grad.Grad = model.Grad;
                var result = dal.EditeGrad(grad);
                if (result) Response.Write("<script> alert('แก้ไข้ข้อมูลสำเร็จ')</script>");
                return RedirectToAction("Subject");
            }
            catch (Exception)
            {
                Response.Write("<scrip> aler('ไม่สำเร็จ')</scrip>");
            }
            return View(model);
        }


        public ActionResult Details(int id)
        {
            var dal = new DAL.RegisterSubDAL();
            var Sub = dal.Search(id);
            return View(Sub);
        }
        
        public ActionResult Grad()
        {
            var model = (Entity.ProfileStudent)Session["Stud"];
            string id = model.Stud_id;
            var dal = new DAL.RegisterSubDAL();
            var Sub = dal.SubGradList();
            Sub = Sub.Where(a => a.Stud_id == id).ToList();
            return View(Sub);
        }

        public ActionResult Subject()
        {
            var model = (Entity.ProfileTeacher)Session["Teacher"];
            string id = model.Teacher_id;
            var dal = new DAL.RegisterSubDAL();
            var Sub = dal.SubList();
            Sub = Sub.Where(a => a.Teacher_id == id).ToList();
            return View(Sub);
        }

        public ActionResult SubList()
        {
            var dal = new DAL.RegisterSubDAL();
            var Sub = dal.SubList();
            return View(Sub);
        }
    }
}