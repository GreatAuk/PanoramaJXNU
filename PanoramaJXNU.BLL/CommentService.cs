using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.BLL
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IBLL;
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CreateDBSession.CommentDal;//在子类里指明具体的数据操作类
        }
    }
}
