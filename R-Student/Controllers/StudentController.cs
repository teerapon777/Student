using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R_Student.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Create()
        {
            using (var db = new Entity.Entities())
            {
                ViewBag.PreName = db.PreName.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Entity.ProfileStudent model)
        {
            var user = (Entity.User)Session["user"];
            var id = user.User_id;
            if (ModelState.IsValid)
            {
                var dal = new DAL.StudentDAL();
                var chk = dal.Chkstud(model);
                if (chk != null)
                {
                    Response.Write("<script> alert('รหัสนักศึกษานี้ถูกลงทะเบียนเเล้ว')</script>");

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

        public ActionResult StudentList()
        {
            var dal = new DAL.StudentDAL();
            var stud = dal.StudentList();
            return View(stud);
        }

        public ActionResult StudHistory()
        {

            var model = (Entity.ProfileStudent)Session["Stud"];
            string id = model.Stud_id;
            var dal = new DAL.StudentDAL();
            var stud = dal.Search(id);
            return View(stud);
        }

        public ActionResult Edit(string id)
        {
            using (var db = new Entity.Entities())
            {
                ViewBag.PreName = db.PreName.ToList();
            }
            var dal = new DAL.StudentDAL();
            var stud = dal.Search(id);
            return View(stud);
        }
        [HttpPost]
        public ActionResult Edit(Entity.ProfileStudent model, string id)
        {
            try
            {
                var dal = new DAL.StudentDAL();
                var stud = dal.Search(id);
                stud.Pre_Name = model.Pre_Name;
                stud.FristName = model.FristName;
                stud.LastName = model.LastName;
                stud.Branch = model.Branch;
                stud.Faculty = model.Faculty;
                var result = dal.EditeStud(stud);
                if (result) Response.Write("<script> alert('แก้ไข้ข้อมูลสำเร็จ')</script>");
                return RedirectToAction("StudHistory");
            }
            catch (Exception)
            {
                Response.Write("<scrip> aler('ไม่สำเร็จ')</scrip>");
            }
            return View(model);
        }
        

        public ActionResult EditStud(string id)
        {
            using (var db = new Entity.Entities())
            {
                ViewBag.PreName = db.PreName.ToList();
            }
            var dal = new DAL.StudentDAL();
            var stud = dal.Search(id);
            return View(stud);
        }
        [HttpPost]
        public ActionResult EditStud(Entity.ProfileStudent model, string id)
        {
            try
            {
                var dal = new DAL.StudentDAL();
                var stud = dal.Search(id);
                stud.Stud_id = model.Stud_id;
                stud.Pre_Name = model.Pre_Name;
                stud.FristName = model.FristName;
                stud.LastName = model.LastName;
                stud.Group_id = model.Group_id;
                stud.Branch = model.Branch;
                stud.Faculty = model.Faculty;
                var result = dal.EditeStud(stud);
                if (result) Response.Write("<script> alert('แก้ไข้ข้อมูลสำเร็จ')</script>");
                return RedirectToAction("StudentList");
            }
            catch (Exception)
            {
                Response.Write("<scrip> aler('ไม่สำเร็จ')</scrip>");
            }
            return View(model);
        }

        public ActionResult Delete(string id)
        {
            var dal = new DAL.StudentDAL();
            var stud = dal.Search(id);
            var result = dal.Delete(stud);
            if (result) Response.Write("<script> alert('ลบข้อมูลเรียบร้อย')</script>");
            return RedirectToAction("StudentList");
        }

        public ActionResult Details(string id)
        {
            var dal = new DAL.StudentDAL();
            var Stud = dal.Search(id);
            return View(Stud);
        }
    }
}