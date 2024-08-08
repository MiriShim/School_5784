using AutoMapper;
using DTO;
using IBL;
using IDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBL
{
    public  class GroupBL : IGroupBL 
    {
        private readonly IGroupDal<SchoolDAL.Model.UserGroup> groupDal;
        private readonly DbContext dbContext;

        public GroupBL(IGroupDal<UserGroup> _groupDal)
        {
            groupDal = _groupDal;   
        }

        public int AddNew(GroupDTO entity)
        {
            MapperConfiguration mConfig = new MapperConfiguration(cfg => 
            cfg.CreateMap<UserGroup, DTO.GroupDTO>().ReverseMap());
            Mapper mapper = new AutoMapper.Mapper(mConfig);

            groupDal.Add(mapper.Map<UserGroup>(entity));
            return 1;
          }      

        public List<GroupDTO> GetAll()
        {
            // return  groupDal.GetAll().Select(a=>(GroupDTO)a).ToList();

            MapperConfiguration mConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserGroup, DTO.GroupDTO>());
            Mapper mapper = new AutoMapper.Mapper(mConfig );

            
           return  groupDal.GetAll().Select(a=>mapper.Map<DTO.GroupDTO >(a)).ToList();
        }

        public object GetGroupsSummery()
        {
            throw new NotImplementedException();
        }
    }
}
