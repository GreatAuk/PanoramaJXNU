using PanoramaJXNU.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.DALFactory
{

    /// <summary>
    /// 反射+配置文件实例化对象
    /// </summary>
  
    public class DalFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];//程序集的名称
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullName = NameSpace + ".UserInfoDal";//MVCmonth4OA.DAL.UserInfoDal
            return (IUserInfoDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
        }
        public static IAdminsDal CreateAdminsDal()
        {
            string fullName = NameSpace + ".AdminsDal";//MVCmonth4OA.DAL.UserInfoDal
            return (IAdminsDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
        }
        public static ICollectDal CreateCollectDal()
        {
            string fullName = NameSpace + ".CollectDal";//MVCmonth4OA.DAL.UserInfoDal
            return (ICollectDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
        }
        public static ICommentDal CreateCommentDal()
        {
            string fullName = NameSpace + ".CommentDal";//MVCmonth4OA.DAL.UserInfoDal
            return (ICommentDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
        }
        public static IFocusDal CreateFocusDal()
        {
            string fullName = NameSpace + ".FocusDal";//MVCmonth4OA.DAL.UserInfoDal
            return (IFocusDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
        }
        public static ILeaveMsgDal CreateLeaveMsgDal()
        {
            string fullName = NameSpace + ".LeaveMsgDal";//MVCmonth4OA.DAL.UserInfoDal
            return (ILeaveMsgDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
        }
           public static ITopicDal CreateTopicDal()
        {
            string fullName = NameSpace + ".TopicDal";//MVCmonth4OA.DAL.UserInfoDal
            return (ITopicDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
        }
           public static ITopicPraiseRecordDal CreateTopicPraiseRecordDal()
           {
               string fullName = NameSpace + ".TopicPraiseRecordDal";//MVCmonth4OA.DAL.UserInfoDal
               return (ITopicPraiseRecordDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
           }
           public static IReplyPraiseRecordDal CreateReplyPraiseRecordDal()
           {
               string fullName = NameSpace + ".ReplyPraiseRecordDal";//MVCmonth4OA.DAL.UserInfoDal
               return (IReplyPraiseRecordDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
           }
           public static IPanoPraiseRecordDal CreatePanoPraiseRecordDal()
           {
               string fullName = NameSpace + ".PanoPraiseRecordDal";//MVCmonth4OA.DAL.UserInfoDal
               return (IPanoPraiseRecordDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
           }
           public static IPanoCollectDal CreatePanoCollectDal()
           {
               string fullName = NameSpace + ".PanoCollectDal";//MVCmonth4OA.DAL.UserInfoDal
               return (IPanoCollectDal)Assembly.Load(AssemblyPath).CreateInstance(fullName);
           }
    }
}
