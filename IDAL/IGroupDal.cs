using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public  interface IGroupDal : IDAL.IObjectDAL
    {
        List<object> GetAllGroupsWithMembersCounter();
    }
}
