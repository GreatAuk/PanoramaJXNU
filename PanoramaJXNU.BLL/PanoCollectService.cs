using PanoramaJXNU.IBLL;
using PanoramaJXNU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.BLL
{
    public class PanoCollectService : BaseService<PanoCollect>, IPanoCollectService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CreateDBSession.PanoCollectDal;
        }
    }
}
