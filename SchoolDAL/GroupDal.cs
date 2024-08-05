using SchoolDAL.Model;
using IDAL;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;


namespace SchoolDAL
{
    
    public class GroupDal : IGroupDal
    {
        
        private readonly Model.SchoolDbContext dbContext;
        private readonly ILogger logger;


        public GroupDal(SchoolDbContext _dbContext,ILogger<GroupDal > _logger )
        { 
             dbContext= _dbContext;  
            logger= _logger;    
        }
        public int Add(object entity)
        {
            try
            {
                //dbContext.UserGroups.Add(entity);
                dbContext.Add(entity);
                dbContext.SaveChanges();

                return 1;
            }
            catch 
             {
                logger.Log(LogLevel.Error, "נכשל בשמירת אוביקט קבוצה");
                return 0; 
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object Get(int id)
        {
            logger.Log(LogLevel.Information, "Get");

            return dbContext.UserGroups.Find(id);

             
        }

        public List<object> GetAll()
        {
             //גם זה תקין::
            // return ctx.UserGroups.Cast<object >().ToList();  
            //או באמצעות פונקציית לינק פשוטה
             return dbContext.UserGroups.Select(a=>(object)a).ToList();  
            
        }

        public List<object> GetAllGroupsWithMembersCounter()
        {
            throw new NotImplementedException();
        }

        public bool Update(object entity)
        {
            return false;
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
