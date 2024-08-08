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
using System.Text.RegularExpressions;
using AutoMapper;


namespace SchoolDAL
{

    public class GroupDal : IGroupDal<UserGroup>
    {
        
        private readonly Model.SchoolDbContext dbContext;
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        private readonly IMapper mapper;



        public GroupDal(SchoolDbContext _dbContext,ILogger<GroupDal> _logger, IConfiguration _configuration ,IMapper _mapper )
        { 
            dbContext= _dbContext;  
            logger= _logger; 
            configuration= _configuration;  
            mapper= _mapper;    
            
        }
        public bool Add(Model.UserGroup  entity)
        {
            try
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();
                logger.Log(LogLevel.Information , $"קבוצה חדשה נשמרה בשם: {entity.GroupName }");

                return true ;
            }
            catch 
             {
                logger.Log(LogLevel.Critical, "נכשל בשמירת אוביקט קבוצה");
                return false ; 
            }
        }

       

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserGroup Get(int id)
        {
            logger.Log(LogLevel.Information, "Get");

            Model.UserGroup  entity= dbContext.UserGroups.Find(id);

            return entity;
        }

        public List<UserGroup> GetAll()
        {
             //גם זה תקין::
            // return ctx.UserGroups.Cast<object >().ToList();  
            //או באמצעות פונקציית לינק פשוטה
             return dbContext.UserGroups.ToList();  
            
        }

        public List<object> GetAllGroupsWithMembersCounter()
        {
            throw new NotImplementedException();
        }

        public bool Update(UserGroup entity)
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
