﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace IBL
{
    public interface IGroupBL : IBL <GroupDTO>
    {
        object GetGroupsSummery();
    }
}
