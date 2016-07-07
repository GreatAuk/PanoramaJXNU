using PanoramaJXNU.IBLL;
using PanoramaJXNU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.BLL
{
    public class PanoPraiseRecordService : BaseService<PanoPraiseRecord>, IPanoPraiseRecordService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CreateDBSession.PanoPraiseRecordDal;//在子类里指明具体的数据操作类
        }
    }
}
