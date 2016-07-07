using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.BLL;
    using PanoramaJXNU.IBLL;

    public class LeaveMsgController : Controller
    {
        LeaveMsgService LeaveMsgService = new LeaveMsgService();
        // GET: /LeaveMsg/
        #region 记录留言
        public ActionResult Send(string content, string receiver)
        {
            //同时存两条记录
            LeaveMsg msg = new LeaveMsg();
            msg.SendTime = System.DateTime.Now;
            msg.Sender = ((UserInfo)Session["UserInfo"]).UserName;
            msg.SenderHead = ((UserInfo)Session["UserInfo"]).HeadImg;
            msg.Receiver = receiver;
            msg.Users = ((UserInfo)Session["UserInfo"]).UserName;
            msg.Friend = receiver;
            msg.Status = 0;
            msg.Content = content;
            LeaveMsgService.AddEntity(msg);

            LeaveMsg msg2 = new LeaveMsg();
            msg2.SendTime = System.DateTime.Now;
            msg2.Sender = ((UserInfo)Session["UserInfo"]).UserName;
            msg2.SenderHead = ((UserInfo)Session["UserInfo"]).HeadImg;
            msg2.Receiver = receiver;
            msg2.Users = receiver;
            msg2.Friend = ((UserInfo)Session["UserInfo"]).UserName;
            msg2.Status = 0;
            msg2.Content = content;
            LeaveMsgService.AddEntity(msg2);
            return Content("ok");
        } 
        #endregion
        #region 删除留言
        public ActionResult Delete(string id)
        {

            //LeaveMsgService.DeleteEntity();
            return Content("ok");
        }
        #endregion
        public ActionResult Send2(string content, string receiver)
        {
           
            return Content("ok");
        }
	}
}