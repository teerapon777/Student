using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R_Student.DAL
{
    public class TeacherDAL
    {
        public Entity.ProfileTeacher Searchteac(int id)
        {
            var teacher = new Entity.ProfileTeacher();
            using (var db = new Entity.Entities())
            {
                teacher = db.ProfileTeacher.Where(a => a.User_id == id).FirstOrDefault();
            }
            return teacher;
        }


        public Entity.ProfileTeacher Chkteac(Entity.ProfileTeacher model)
        {
            var teacher = new Entity.ProfileTeacher();

            using (var db = new Entity.Entities())
            {
                teacher = db.ProfileTeacher.Where(a => a.Teacher_id == model.Teacher_id).FirstOrDefault();
            }
            return teacher;
        }


        internal bool Create(Entity.ProfileTeacher model, int id)
        {
            try
            {
                int user = id;
                using (var db = new Entity.Entities())
                {
                    model.User_id = user;
                    db.Entry(model).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Entity.ProfileTeacher> TeacherList()
        {
            var teacher = new List<Entity.ProfileTeacher>();
            using (var db = new Entity.Entities())
            {
                teacher = db.ProfileTeacher.ToList();
                foreach (var s in teacher)
                {
                    s.PreName = s.PreName;
                    s.User = s.User;
                }
            }
            return teacher;
        }

        
        public Entity.ProfileTeacher Search(string id)
        {
            var teacher = new Entity.ProfileTeacher();
            using (var db = new Entity.Entities())
            {
                teacher = db.ProfileTeacher.Where(a => a.Teacher_id == id).FirstOrDefault();
                teacher.User = teacher.User;
                teacher.PreName = teacher.PreName;
            }
            return teacher;
        }


        internal bool EditeTeacher(Entity.ProfileTeacher model)
        {
            try
            {
                using (var db = new Entity.Entities())
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        internal bool Delete(Entity.ProfileTeacher model)
        {
            try
            {
                using (var db = new Entity.Entities())
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}