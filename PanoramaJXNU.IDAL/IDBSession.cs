using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.IDAL
{
    /// <summary>
    /// DBSession的接口，供BLL调用
    /// BLL调用IDBSession，实例化出DBSession对象，还有统一保存函数
    /// DBSession里创建了UserInfoDal的对象（其中UserInfoDal又是在DalFactory里使用反射+配置文件创建的对象）
    /// </summary>
    public interface IDBSession
    {
        IUserInfoDal UserInfoDal
        {
            get;
            set;
        }
        IAdminsDal AdminsDal
        {
            get;
            set;
        }
        ICollectDal CollectDal
        {
            get;
            set;
        }
        ICommentDal CommentDal
        {
            get;
            set;
        }
        IFocusDal FocusDal
        {
            get;
            set;
        }
        ILeaveMsgDal LeaveMsgDal
        {
            get;
            set;
        }
        ITopicDal TopicDal
        {
            get;
            set;
        }
        ITopicPraiseRecordDal TopicPraiseRecordDal
        {
            get;
            set;
        }
        IReplyPraiseRecordDal ReplyPraiseRecordDal
        {
            get;
            set;
        }
        IPanoPraiseRecordDal PanoPraiseRecordDal
        {
            get;
            set;
        }

        IPanoCollectDal PanoCollectDal
        {
            get;
            set;
        }
        bool SaveChanges();
    }
}
