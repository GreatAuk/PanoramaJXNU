using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.BLL
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IBLL;
    public class TopicService : BaseService<Topic>, ITopicService
    {

        public override void SetCurrentDal()
        {
            CurrentDal = this.CreateDBSession.TopicDal;//在子类里指明具体的数据操作类
        }
        public IQueryable<Topic> LoadTop(int top)
        { 
            var list=this.CreateDBSession.TopicDal.LoadTop(top);
            this.CreateDBSession.SaveChanges();
            return list;
            
        }
    }
}
