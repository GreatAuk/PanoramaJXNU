using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.IBLL;
    using PanoramaJXNU.Model;
    public class ReplyPraiseRecordController : Controller
    {
        IReplyPraiseRecordService ReplyPraiseRecordService { get; set; }
        //
        // GET: /ReplyPraiseRecord/
        #region 判断记录表中是否存在点赞记录
        public ActionResult IsExit()
        {
            int commentId = Convert.ToInt32(Request["commentId"]);
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            int userid = ((UserInfo)Session["UserInfo"]).UserId;
            if (ReplyPraiseRecordService.LoadEntities(c => c.UserId == userid && c.CommentId == commentId).FirstOrDefault() == null)
            {
                return Content("do");
            }
            return Content("exit");
        }
        #endregion
        #region 记录点赞
        public ActionResult Record()
        {
            ReplyPraiseRecord record = new ReplyPraiseRecord();
            record.UserId = ((UserInfo)Session["UserInfo"]).UserId;
            record.CommentId = Convert.ToInt32(Request["commentId"]);
            record.Time = System.DateTime.Now;
            ReplyPraiseRecordService.AddEntity(record);
            return Content("ok");
        }
        #endregion
	}
}