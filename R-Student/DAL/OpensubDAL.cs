using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R_Student.DAL
{
    public class OpensubDAL
    {
        internal bool Create(Entity.Open_Subjects model, string id)
        {
            try
            {
                string tecger = id;
                using (var db = new Entity.Entities())
                {
                    model.Teacher_id = tecger;
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

        public Entity.Open_Subjects ChkSub(Entity.Open_Subjects model)
        {
            var Sub = new Entity.Open_Subjects();

            using (var db = new Entity.Entities())
            {
                Sub = db.Open_Subjects.Where(a => a.Sub_id == model.Sub_id).FirstOrDefault();
            }
            return Sub;
        }
    }
}