using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R_Student.DAL
{
    public class StudentDAL
    {
        public Entity.ProfileStudent Chkstud(Entity.ProfileStudent model)
        {
            var stud = new Entity.ProfileStudent();

            using (var db = new Entity.Entities())
            {
                stud = db.ProfileStudent.Where(a => a.Stud_id == model.Stud_id).FirstOrDefault();
            }
            return stud;
        }

        internal bool Create(Entity.ProfileStudent model,int id)
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

        public List<Entity.ProfileStudent> StudentList()
        {
            var stud = new List<Entity.ProfileStudent>();
            using (var db = new Entity.Entities())
            {
                stud = db.ProfileStudent.ToList();
                foreach (var s in stud)
                {
                    s.PreName = s.PreName;
                    s.User = s.User;
                }
            }
            return stud;
        }


        public Entity.ProfileStudent Searchstud(int id)
        {
            var stud = new Entity.ProfileStudent();
            using (var db = new Entity.Entities())
            {
                stud = db.ProfileStudent.Where(a => a.User_id == id).FirstOrDefault();
            }
            return stud;
        }


        public Entity.ProfileStudent Search(string id)
        {

            var stud = new Entity.ProfileStudent();
            using (var db = new Entity.Entities())
            {
                stud = db.ProfileStudent.Where(a => a.Stud_id == id).FirstOrDefault();
                stud.PreName = stud.PreName;
                stud.User = stud.User;
            }
            return stud;
        }
      

        internal bool EditeStud(Entity.ProfileStudent model)
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


        internal bool Delete(Entity.ProfileStudent model)
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