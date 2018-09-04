using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R_Student.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Create()
        {
            using (var db = new Entity.Entities())
            {
                ViewBag.PreName = db.PreName.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Entity.ProfileTeacher model)
        {
            var user = (Entity.User)Session["user"];
            var id = user.User_id;
            if (ModelState.IsValid)
            {
                var dal = new DAL.TeacherDAL();
                var chk = dal.Chkteac(model);
                if (chk != null)
                {
                    Response.Write("<script> alert('รหัสอาจารย์นี้ถูกลงทะเบียนเเล้ว')</script>");

                }
                else
                {
                    var result = dal.Create(model, id);
                    if (result) Response.Write("<script> alert('ลงทะเบียนสำเร็จ')</script>");
                    return RedirectToAction("index", "User");
                }
                return View();

            }
            return View(model);
        }


        public ActionResult TeacherList()
        {
            var dal = new DAL.TeacherDAL();
            var teacher = dal.TeacherList();
            return View(teacher);
        }


        public ActionResult TeacherHistory()
        {

            var model = (Entity.ProfileTeacher)Session["Teacher"];
            string id = model.Teacher_id;
            var dal = new DAL.TeacherDAL();
            var teacher = dal.Search(id);
            return View(teacher);
        }


        public ActionResult Edit(string id)
        {
            using (var db = new Entity.Entities())
            {
                ViewBag.PreName = db.PreName.ToList();
            }
            var dal = new DAL.TeacherDAL();
            var teacher = dal.Search(id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult Edit(Entity.ProfileTeacher model, string id)
        {
            try
            {
                var dal = new DAL.TeacherDAL();
                var teacher = dal.Search(id);
                teacher.Pre_Name = model.Pre_Name;
                teacher.FristName = model.FristName;
                teacher.LastName = model.LastName;
                teacher.Branch = model.Branch;
                teacher.Faculty = model.Faculty;
                var result = dal.EditeTeacher(teacher);
                if (result) Response.Write("<script> alert('แก้ไข้ข้อมูลสำเร็จ')</script>");
                return RedirectToAction("TeacherHistory");
            }
            catch (Exception)
            {
                Response.Write("<scrip> aler('ไม่สำเร็จ')</scrip>");
            }
            return View(model);
        }     


        public ActionResult EditTeacher(string id)
        {
            using (var db = new Entity.Entities())
            {
                ViewBag.PreName = db.PreName.ToList();
            }
            var dal = new DAL.TeacherDAL();
            var teacher = dal.Search(id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult EditTeacher(Entity.ProfileTeacher model, string id)
        {
            try
            {
                var dal = new DAL.TeacherDAL();
                var teacher = dal.Search(id);
                teacher.Teacher_id = model.Teacher_id;
                teacher.Pre_Name = model.Pre_Name;
                teacher.FristName = model.FristName;
                teacher.LastName = model.LastName;
                teacher.Branch = model.Branch;
                teacher.Faculty = model.Faculty;
                var result = dal.EditeTeacher(teacher);
                if (result) Response.Write("<script> alert('แก้ไข้ข้อมูลสำเร็จ')</script>");
                return RedirectToAction("TeacherList");
            }
            catch (Exception)
            {
                Response.Write("<scrip> aler('ไม่สำเร็จ')</scrip>");
            }
            return View(model);
        }


        public ActionResult Delete(string id)
        {
            var dal = new DAL.TeacherDAL();
            var teacher = dal.Search(id);
            var result = dal.Delete(teacher);
            if (result) Response.Write("<script> alert('ลบข้อมูลเรียบร้อย')</script>");
            return RedirectToAction("TeacherList");
        }


        public ActionResult Details(string id)
        {
            var dal = new DAL.TeacherDAL();
            var teacher = dal.Search(id);
            return View(teacher);
        }
    }
}