﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.IBLL
{
    using PanoramaJXNU.Model;
   public  interface ITopicService : IBaseService<Topic>
    {
       IQueryable<Topic> LoadTop(int top);
    }
}
