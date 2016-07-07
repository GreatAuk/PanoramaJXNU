using PanoramaJXNU.IBLL;
using PanoramaJXNU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CreateDBSession.UserInfoDal;//在子类里指明具体的数据操作类
        }
        
        /// <summary>
        /// 增加一个一次删除多个数据的方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            //已经有ID的值了，方法DeleteEntity(T entity)需要传一个T形的数据，这里T是UserInfoSet
            //所以仅有一个ID是不行的，这里需要一个数据集

            var userInfoList = this.CreateDBSession.UserInfoDal.LoadEntities(U => list.Contains(U.UserId));//查询
            //list.Contains(U.ID)，当该集合存在数据U.ID时，返回true

            //使用循环将选择的数据集打上删除标记
            foreach (var userinfo in userInfoList)
            {
                this.CreateDBSession.UserInfoDal.DeleteEntity(userinfo);
            }
            return this.CreateDBSession.SaveChanges();
        }
    }
}
