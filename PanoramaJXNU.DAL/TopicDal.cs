using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.DAL
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IDAL;
    using System.Data.Entity;
    public class TopicDal : BaseDal<Topic>, ITopicDal
    {
        DbContext DB = DbContextFactory.InstanceDbContext;
        public IQueryable<Topic> LoadTop(int top)
        {
            var list=DB.Set<Topic>().Where(c => c.Id != -1).OrderByDescending(c=>c.Id).Take(top);
            return list;
        }
    }
}
