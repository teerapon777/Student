using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R_Student.DAL
{
    public class RegisterSubDAL
    {
        public Entity.Register_Subjects ChkSub(Entity.Register_Subjects model)
        {
            var Sub = new Entity.Register_Subjects();

            using (var db = new Entity.Entities())
            {
                Sub = db.Register_Subjects.Where(a => a.Sub_id == model.Sub_id && a.Stud_id == model.Stud_id).FirstOrDefault();
            }
            return Sub;
        }

        public List<Entity.Open_Subjects> SubList()
        {
            var Sub = new List<Entity.Open_Subjects>();
            using (var db = new Entity.Entities())
            {
                Sub = db.Open_Subjects.ToList();
                foreach (var s in Sub)
                {
                    s.ProfileTeacher = s.ProfileTeacher;
                }
            }
            return Sub;
        }

        public List<Entity.Register_Subjects> SubGradList()
        {
            var model = new Entity.Open_Subjects();
            var Sub = new List<Entity.Register_Subjects>();
            using (var db = new Entity.Entities())
            {
                Sub = db.Register_Subjects.ToList();
                foreach (var s in Sub)
                {

                    s.Open_Subjects = s.Open_Subjects;
                }
            }
            return Sub;
        }


        internal bool Create(Entity.Register_Subjects model, string Stud)
        {
            try
            {
                
                using (var db = new Entity.Entities())
                {
                    model.Stud_id = Stud;
                    model.Grad = "I";
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

        public Entity.Open_Subjects Search(int id)
        {
            var sub = new Entity.Open_Subjects();
            using (var db = new Entity.Entities())
            {
                sub = db.Open_Subjects.Where(a => a.Sub_id == id).FirstOrDefault();
                sub.ProfileTeacher = sub.ProfileTeacher;
                
            }
            return sub;
        }

        public Entity.Register_Subjects Searchgrad(int id)
        {
            var sub = new Entity.Register_Subjects();
            using (var db = new Entity.Entities())
            {
                sub = db.Register_Subjects.Where(a => a.id == id).FirstOrDefault();
                sub.Open_Subjects = sub.Open_Subjects;

            }
            return sub;
        }

        internal bool EditeGrad(Entity.Register_Subjects model)
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
    }
}