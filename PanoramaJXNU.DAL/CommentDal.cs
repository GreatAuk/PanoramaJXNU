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
    public class CommentDal : BaseDal<Comment>, ICommentDal
    {
    }
}
