using IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBL
{
    public  class GroupBL : IBL.IGroupBL 
    {
        private readonly IDAL.IGroupDal groupDal;
        private readonly DbContext dbContext;

        public GroupBL(IGroupDal _groupDal)
        {
            groupDal = _groupDal;   
         }

        public int AddNew(object entity)
        {
              groupDal.Add(entity);
            //have to return the new id
            return 0;
        }

        public List<object> GetAll()
        {
           return  groupDal.GetAll();
        }

        public object GetGroupsSummery()
        {
            throw new NotImplementedException();
        }
    }
}
