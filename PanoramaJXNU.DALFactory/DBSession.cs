using PanoramaJXNU.DAL;
using PanoramaJXNU.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.DALFactory
{
    /// <summary>
    /// 这是DAL与BLL进行交互的桥梁
    /// </summary>
    public class DBSession : IDBSession
    {
        //MVC04OAEntities DB = new MVC04OAEntities();//直接new的情况，这是一个封装点，重复new将导致线程捏不唯一

        ///将UserInfoDal的实例化封装成属性
        private IUserInfoDal _UserInfoDal;
        private IAdminsDal _AdminsDal;
        private ICollectDal _CollectDal;
        private ICommentDal _CommentDal;
        private IFocusDal _FocusDal;
        private ILeaveMsgDal _LeaveMsgDal;
        private ITopicDal _TopicDal;
        private ITopicPraiseRecordDal _TopicPraiseRecordDal;
        private IReplyPraiseRecordDal _IReplyPraiseRecordDal;
        private IPanoPraiseRecordDal _PanoPraiseRecordDal;
        private IPanoCollectDal _PanoCollectDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_UserInfoDal == null)
                {
                    //_UserInfoDal=new UserInfoDal(); //直接new，这是一个封装点，重复new将导致线程内不唯一
                    //直接new导致DAL与DALFactory耦合在一起了
                    //使用反射+配置文件的方法来创建UserInfoDal的对象

                    _UserInfoDal = DalFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }


       


        public IAdminsDal AdminsDal
        {
            get
            {

                if (_AdminsDal == null)
                {
                    AdminsDal = DalFactory.CreateAdminsDal();
                }
                return _AdminsDal;
            }
            set
            {
                _AdminsDal = value; 
            }
        }

        public ICollectDal CollectDal
        {
            get
            {

                if (_CollectDal == null)
                {
                    _CollectDal = DalFactory.CreateCollectDal();
                }
                return _CollectDal;
            }
            set
            {
                _CollectDal = value;
            }
        }

        public ICommentDal CommentDal
        {
            get
            {

                if (_CommentDal == null)
                {
                    _CommentDal = DalFactory.CreateCommentDal();
                }
                return _CommentDal;
            }
            set
            {
                _CommentDal = value;
            }
        }

        public IFocusDal FocusDal
        {
            get
            {

                if (_FocusDal == null)
                {
                    _FocusDal = DalFactory.CreateFocusDal();
                }
                return _FocusDal;
            }
            set
            {
                _FocusDal = value;
            }
        }

        public ILeaveMsgDal LeaveMsgDal
        {
            get
            {

                if (_LeaveMsgDal == null)
                {
                    _LeaveMsgDal = DalFactory.CreateLeaveMsgDal();
                }
                return _LeaveMsgDal;
            }
            set
            {
                _LeaveMsgDal = value;
            }
        }

        public ITopicDal TopicDal
        {
            get
            {

                if (_TopicDal == null)
                {
                    _TopicDal = DalFactory.CreateTopicDal();
                }
                return _TopicDal;
            }
            set
            {
                _TopicDal = value;
            }
        }
        public ITopicPraiseRecordDal TopicPraiseRecordDal
        {
            get
            {

                if (_TopicPraiseRecordDal == null)
                {
                    _TopicPraiseRecordDal = DalFactory.CreateTopicPraiseRecordDal();
                }
                return _TopicPraiseRecordDal;
            }
            set
            {
                _TopicPraiseRecordDal = value;
            }
        }
        public IReplyPraiseRecordDal ReplyPraiseRecordDal
        {
            get
            {

                if (_IReplyPraiseRecordDal == null)
                {
                    _IReplyPraiseRecordDal = DalFactory.CreateReplyPraiseRecordDal();
                }
                return _IReplyPraiseRecordDal;
            }
            set
            {
                _IReplyPraiseRecordDal = value;
            }
        }
        public IPanoPraiseRecordDal PanoPraiseRecordDal
        {
            get
            {
                if (_PanoPraiseRecordDal == null)
                {

                    _PanoPraiseRecordDal = DalFactory.CreatePanoPraiseRecordDal();
                }
                return _PanoPraiseRecordDal;
            }
            set { _PanoPraiseRecordDal = value; }
        }
        public IPanoCollectDal PanoCollectDal
        {
            get
            {
                if (_PanoCollectDal == null)
                {
                    _PanoCollectDal = DalFactory.CreatePanoCollectDal();
                }
                return _PanoCollectDal;
            }
            set { _PanoCollectDal = value; }
        }
        /// <summary>
        /// 封装统一的保存点
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return DbContextFactory.InstanceDbContext.SaveChanges() > 0;
        }


    }
}
