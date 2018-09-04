using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R_Student.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Login model)
        {
            if (ModelState.IsValid)
            {
                var daluser = new DAL.UserDAL();
                var user = daluser.Login(model);
                if (user != null)
                {
                    Session["USER"] = user;
                    var sestud = (Entity.User)Session["USER"];
                    int id = sestud.User_id;
                    var dalstud = new DAL.StudentDAL();
                    var stud = dalstud.Searchstud(id);
                    if (stud != null)
                    {
                        Session["Stud"] = stud;
                    }
                    var dalteac = new DAL.TeacherDAL();
                    var teacher = dalteac.Searchteac(id);
                    if (teacher != null)
                    {
                        Session["Teacher"] = teacher;
                    }
                    return RedirectToAction("Index", "User");
                }
                else Response.Write("<script> alert('ไม่พบผู้ใช้')</script>");               
                
            }
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Entity.User model)
        {
            #region Upload Picture // จัดการบันทึกรูปภาพ
            HttpPostedFileBase Image = Request.Files["Image"]; //อ่านภาพต้นฉบับ

            if (Image != null && Image.ContentLength > 0)
            {
                string filename = Path.GetFileName(Image.FileName);
                string SavePath = Server.MapPath("~/UploadPicture");
                if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);

                Image.SaveAs(SavePath + "/" + filename);   //บันทึกไฟล์ภาพ
                model.Image = "UploadPicture/" + filename; //ชื่อไฟล์และพาท
            }
            #endregion
            if (ModelState.IsValid)
            {
                var dal = new DAL.UserDAL();
                var chk = dal.Chkuser(model);
                if (chk != null)
                {
                    Response.Write("<script> alert('มีชื่อผู้ใช้นี้แล้ว')</script>");

                }
                else {
                    var result = dal.CreateUser(model);
                    if (result) Response.Write("<script> alert('ลงทะเบียนสำเร็จ')</script>");
                    return RedirectToAction("UserList", "User");
                }
                return View();

            }
            return View(model);
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Entity.User model)
        {
            #region Upload Picture // จัดการบันทึกรูปภาพ
            HttpPostedFileBase Image = Request.Files["Image"]; //อ่านภาพต้นฉบับ

            if (Image != null && Image.ContentLength > 0)
            {
                string filename = Path.GetFileName(Image.FileName);
                string SavePath = Server.MapPath("~/UploadPicture");
                if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);

                Image.SaveAs(SavePath + "/" + filename);   //บันทึกไฟล์ภาพ
                model.Image = "UploadPicture/" + filename; //ชื่อไฟล์และพาท
            }
            #endregion
            if (ModelState.IsValid)
            {
                var dal = new DAL.UserDAL();
                var chk = dal.Chkuser(model);
                if (chk != null)
                {
                    Response.Write("<script> alert('มีชื่อผู้ใช้นี้แล้ว')</script>");

                }
                else
                {
                    var result = dal.Register(model);
                    if (result) Response.Write("<script> alert('ลงทะเบียนสำเร็จ')</script>");
                    return RedirectToAction("Login", "User");
                }
                return View();

            }
            return View(model);
        }


        public ActionResult EditeUser()
        {
            var model = (Entity.User)Session["user"];
            ViewBag.Image = model.Image;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditeUser(Entity.User model)
        {
            try              
            {
                var ses = (Entity.User)Session["user"];
                int id = ses.User_id;
                var dal = new DAL.UserDAL();
                var user = dal.Search(id);
                user.Password = model.Password;
                user.Name = model.Name;
                
               
                #region Upload Picture // จัดการบันทึกรูปภาพ
                HttpPostedFileBase Image = Request.Files["Image"]; //อ่านภาพต้นฉบับ

                if (Image != null && Image.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Image.FileName);
                    string SavePath = Server.MapPath("~/UploadPicture");
                    if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);

                    Image.SaveAs(SavePath + "/" + filename);   //บันทึกไฟล์ภาพ
                    user.Image = "UploadPicture/" + filename; //ชื่อไฟล์และพาท
                }
                
                #endregion
            
            var result = dal.EditeUser(user);
            if (result) Response.Write("<script> alert('แก้ไขข้อมูลสำเร็จ')</script>");
            return RedirectToAction("index");
            }
            catch (Exception)
            {
                Response.Write("<scrip> aler('ไม่สำเร็จ')</scrip>");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var dal = new DAL.UserDAL();
            var user = dal.Search(id);
            ViewBag.Image = user.Image;
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Entity.User model, int id)
        {           
            try
            {
                var dal = new DAL.UserDAL();
                var user = dal.Search(id);

                user.Username = model.Username;
                user.Password = model.Password;
                user.Name = model.Name;
                user.Usertype = model.Usertype;
               

                #region Upload Picture // จัดการบันทึกรูปภาพ
                HttpPostedFileBase Image = Request.Files["Image"]; //อ่านภาพต้นฉบับ

                if(Image != null)
                {
                    if (Image != null && Image.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(Image.FileName);
                        string SavePath = Server.MapPath("~/UploadPicture");
                        if (!Directory.Exists(SavePath)) Directory.CreateDirectory(SavePath);

                        Image.SaveAs(SavePath + "/" + filename);   //บันทึกไฟล์ภาพ
                        user.Image = "UploadPicture/" + filename; //ชื่อไฟล์และพาท
                    }
                    

                }
                
                #endregion


                var result = dal.EditeUser(user);
                if (result) Response.Write("<script> alert('แก้ไข้ข้อมูลสำเร็จ')</script>");
                return RedirectToAction("UserList");
            }
            catch (Exception)
            {
                Response.Write("<scrip> aler('ไม่สำเร็จ')</scrip>");
            }
            return View(model);
        }


        public ActionResult UserList()
        {
            var dal = new DAL.UserDAL();
            var user = dal.UserList();
            return View(user);
        }


        public ActionResult Details(int id)
        {
            var dal = new DAL.UserDAL();
            var user = dal.Search(id);
            return View(user);
        }


        public ActionResult Delete(int id)
        {
            var dal = new DAL.UserDAL();
            var user = dal.Search(id);
            var result = dal.Delete(user);
            if (result) Response.Write("<script> alert('ลบข้อมูลเรียบร้อย')</script>");
            return RedirectToAction("UserList");
        }
    }
}