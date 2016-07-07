using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.BLL
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IBLL;
    public class LeaveMsgService : BaseService<LeaveMsg>, ILeaveMsgService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CreateDBSession.LeaveMsgDal;//在子类里指明具体的数据操作类
        }
    }
}
