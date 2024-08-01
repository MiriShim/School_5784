using SchoolDAL.Model;
using System;
using System.Threading.Tasks;

namespace SchoolDAL
{
    public class UserDal :  IDAL.IObjectDAL
    {
        //   public bool Add(User user)
        //   {
        //       try {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           ctx.Users.Add(user);
        ////האם יש הבדל???           ctx.Add(user);
        //           ctx.SaveChanges();
        //           return true;
        //       }
        //       catch {
        //           return false;
        //       }

        //   }

        //   public List<User> GetAll()
        //   {
        //       try
        //       {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           List<User> users = new List<User>();
        //           users.AddRange(ctx.Users);
        //           return users;
        //       }
        //       catch
        //       {
        //           return null;
        //       }
        //   }

        //   public User Get(int id)
        //   {

        //       try {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //            User user = ctx.Users.Find(id);
        //           return user;
        //       }
        //       catch {
        //           return null;
        //       }
        //       throw new NotImplementedException();
        //   }

        //   public bool Delete(int id)
        //   {
        //       try
        //       {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           User user = ctx.Users.Find(id);
        //           ctx.Users.Remove(user);
        //           ctx.SaveChanges();
        //           return true;
        //       }

        //       catch
        //       {
        //           return false;
        //       }

        //   }
        //   public bool Update(User user)
        //   {
        //       try
        //       {
        //           using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
        //           int id = user.UserId;
        //           User oldUser = ctx.Users.Find(id);
        //           //
        //           oldUser = ctx.Users.Find(id);
        //          // ctx.Users.FindUpdate.Find(id)(user);
        //           //
        //           ctx.SaveChanges();
        //           return true;
        //       }

        //       catch
        //       {
        //           return false;
        //       }
        //   }
        public bool Add(object entity)
        {
            try
            {
                using Model.UserGittyDbContext ctx = new Model.UserGittyDbContext();
                ctx.Add(entity );
                //האם יש הבדל???           ctx.Add(user);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
