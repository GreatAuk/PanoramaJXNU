using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IBLL;
    public class TopicPraiseRecordController : Controller
    {
        ITopicPraiseRecordService TopicPraiseRecordService { get; set; }
        //
        // GET: /TopicPraiseRecord/
        #region 判断记录表中是否存在点赞记录
        public ActionResult IsExit()
        {
            int topicid = Convert.ToInt32(Request["topicid"]);
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            int userid = ((UserInfo)Session["UserInfo"]).UserId;
            if (TopicPraiseRecordService.LoadEntities(c => c.UserId == userid && c.TopicId == topicid).FirstOrDefault() == null)
            {
                return Content("do");
            }
            return Content("exit");
        } 
        #endregion
        #region 记录点赞
        public ActionResult Record()
        {
            TopicPraiseRecord record = new TopicPraiseRecord();
            record.UserId = ((UserInfo)Session["UserInfo"]).UserId;
            record.TopicId = Convert.ToInt32(Request["topicid"]);
            record.Time = System.DateTime.Now;
            TopicPraiseRecordService.AddEntity(record);
            return Content("ok");
        } 
        #endregion
	}
}