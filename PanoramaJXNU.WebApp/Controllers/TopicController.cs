using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IBLL;

    public class TopicController : Controller
    {
        ITopicService TopicService { get; set; }
      
        //
        // GET: /Topic/
        #region 论坛首页
        public ActionResult Index()
        {
            if (Session["UserInfo"] == null)
            {
                ViewBag.headImg = "None";
            }
            else
            {
                ViewBag.headImg = ((UserInfo)Session["UserInfo"]).HeadImg;
            }
            int totalCount = (TopicService.LoadEntities(c => c.Id != -1).ToList()).Count();
            ViewBag.pageCount = Math.Ceiling((totalCount / Convert.ToDecimal(8)));
            return View();
        } 
        #endregion

        #region 帖子分部视图
        public ActionResult Partial(int pageindex)
        {
            int totalCount;
           
            ViewBag.topic = TopicService.LoadPageEntities(pageindex, 8, out totalCount, c => c.Id != -1, c => c.Id, false).ToList();

            return PartialView();
        } 
        #endregion

        #region 帖子详细
        public ActionResult Detail()
        {
            if (Session["UserInfo"] == null)
            {
                ViewBag.headImg = "None";
            }
            else
            {
                ViewBag.headImg = ((UserInfo)Session["UserInfo"]).HeadImg;
            }
            int id = Convert.ToInt32(Request.QueryString["topicid"]);
            Topic topic = TopicService.LoadEntities(c => c.Id == id).FirstOrDefault();
            return View(topic);
        } 
        #endregion

        #region 发帖
        [ValidateInput(false)]  //让服务器可以接收富文本编辑器传的input标签,同时也要将配置文件中的<httpRuntime targetFramework="4.5"/>改成<httpRuntime targetFramework="4.5" requestValidationMode="2.0"/>
        public ActionResult CreateTopic()
        {
            Topic topic = new Topic();
            topic.Title = Request["title"].ToString();
            topic.Content = Request["content"].ToString();
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            topic.UserId = ((UserInfo)Session["UserInfo"]).UserId;
            topic.UserName = ((UserInfo)Session["UserInfo"]).UserName;
            topic.CreateTime = DateTime.Now;
            topic.BroseCount = 0;
            topic.Status = 1;
            topic.ReplyCount = 0;
            TopicService.AddEntity(topic);
            return Content("ok");
        } 
        #endregion

        #region Test
        public ActionResult test()
        {
            string str = TopicService.LoadEntities(c => c.Id == 15).FirstOrDefault().Content;
            int start = 0;
            int end = 0;

            if ((start = str.IndexOf("<img")) != -1)
            {
                end = str.IndexOf(">", start);

            } ViewBag.img = str.Substring(start, end - start + 1);
            return View();
        } 
        #endregion

        #region 帖子点赞
        public ActionResult Prasie()
        {
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            int id = Convert.ToInt32( Request.QueryString["topicid"]);
            Topic topic= TopicService.LoadEntities(c => c.Id == id).FirstOrDefault();
            topic.PraiseCount = topic.PraiseCount + 1;
            TopicService.EditEntity(topic);
            return Content("ok");
        } 
        #endregion

        #region 新话题(分部视图）
        public ActionResult NewTopic()
        {
            var list= TopicService.LoadTop(8).ToList();
            return PartialView(list);
        }
        #endregion
    }
}