using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R_Student.DAL
{
    public class UserDAL
    {
        public Entity.User Login(Models.Login model)
        {
            var user = new Entity.User();

            using (var db = new Entity.Entities())
            {
                user = db.User.Where(a => a.Username == model.Username
                && a.Password == model.Password).FirstOrDefault();
            }
            return user;
        }

        public Entity.User Chkuser(Entity.User model)
        {
            var user = new Entity.User();

            using (var db = new Entity.Entities())
            {
                user = db.User.Where(a => a.Username == model.Username).FirstOrDefault();
            }
            return user;
        }

        public Entity.User Search(int id)
        {
            var user = new Entity.User();
            using (var db = new Entity.Entities())
            {
                user = db.User.Where(a => a.User_id == id).FirstOrDefault();
            }
            return user;
        }

        internal bool Register(Entity.User model)
        {
            try
            {
                using (var db = new Entity.Entities())
                {
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

        internal bool CreateUser(Entity.User model)
        {
            try
            {
                using (var db = new Entity.Entities())
                {
                    model.Usertype = 3;
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

        internal bool EditeUser(Entity.User model)
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

        public List<Entity.User> UserList()
        {
            var user = new List<Entity.User>();
            using (var db = new Entity.Entities())
            {
                user = db.User.ToList();
            }
            return user;
        }

        internal bool Delete(Entity.User model)
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