using SchoolDAL.Model;
using IDAL;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SchoolDAL
{
    
    public class GroupDal : IGroupDal
    {
        
        private readonly DbContext dbContext;
        


        public GroupDal(DbContext _dbContext )
        {
                dbContext= _dbContext;  
        }
        public bool Add(object entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object Get(int id)
        {
            //using UserGittyDbContext ctx = new UserGittyDbContext();
             
            return ((UserGittyDbContext)dbContext).UserGroups.Find(id);
        }

        public List<object> GetAll()
        {
            using  UserGittyDbContext ctx = new  UserGittyDbContext();
            //גם זה תקין::
            // return ctx.UserGroups.Cast<object >().ToList();  
            //או באמצעות פונקציית לינק פשוטה
             return ctx.UserGroups.Select(a=>(object)a).ToList();  
            
        }

        public List<object> GetAllGroupsWithMembersCounter()
        {
            throw new NotImplementedException();
        }

        public bool Update(object entity)
        {
            throw new NotImplementedException();
        }
    }

    //internal class GroupDal : IDAL.IGeneralDAL<Model.UserGroup>
    //{
    //    public bool Add(UserGroup entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public UserGroup Get(int id)
    //    {
    //         throw new NotImplementedException();
    //    }

    //    public List<UserGroup> GetAll()
    //    {
    //       try
    //        {
    //           using  Model.UserGittyDbContext ctx = new();
    //            return ctx.UserGroups.Include(a=>a.UserGroupMemberships).ToList();

    //        }
    //        catch { return null; }
    //    }
    //    public List<object > GetAllGroupsWithMembersCounter()
    //    {
    //        try
    //        {
    //            using Model.UserGittyDbContext ctx = new();
    //            return ctx.UserGroups.Select(g=>(object)new {g.GroupId,g.GroupName,Counter=g.UserGroupMemberships.Count  }).ToList();

    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public bool Update(UserGroup entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
