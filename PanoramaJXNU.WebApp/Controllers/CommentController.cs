using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.IBLL;
    using PanoramaJXNU.Model;
    public class CommentController : Controller
    {
        ICommentService CommentService { get; set; }
        //
        // GET: /Comment/
        #region 快速回复
        public ActionResult QuickReply()
        { 
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            Comment com = new Comment();
            com.Content = Request["content"].ToString();
            com.TopicTitle = Request["title"].ToString();
            com.TopicId = Convert.ToInt32(Request["topicid"]);
            if (Request["commentId"]!=null)
            {
                com.CommentId = Convert.ToInt32(Request["commentId"]); 
            }
            com.UserName = ((UserInfo)Session["UserInfo"]).UserName;
            com.UserImg = ((UserInfo)Session["UserInfo"]).HeadImg;
            com.CreatTime = DateTime.Now;
           
            com.UserId = ((UserInfo)Session["UserInfo"]).UserId;
            com.Status = 1;
            com.Praise = 0;
            com.TopicUserId = Convert.ToInt32(Request["topicuserid"]);
            CommentService.AddEntity(com);
            ViewBag.headImg = ((UserInfo)Session["UserInfo"]).HeadImg;
            return Content("ok");
        } 
        #endregion

        #region 对回复点赞
        public ActionResult Prasie()
        {
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            int commentId =Convert.ToInt32( Request["commentId"]);
            Comment com= CommentService.LoadEntities(c=>c.Id==commentId).FirstOrDefault();
            com.Praise = com.Praise + 1;
            CommentService.EditEntity(com);
            return Content("ok");
        }
        #endregion

        #region 发现
        public ActionResult DisCover()
        {
            var list = CommentService.LoadEntities(c => c.Id != -1).Take(8).ToList();
            return PartialView(list);
        }
        #endregion

        #region 显示帖子回复
        public ActionResult ShowReply(int TopicId,int index)
        {
           //var list= CommentService.LoadEntities(c => c.TopicId == TopicId).OrderByDescending(c=>c.Id).ToList();

           int totalCount;

            var list = CommentService.LoadPageEntities(index, 5, out totalCount, c => c.TopicId==TopicId, c => c.Id, false).OrderByDescending(c=>c.Id).ToList();

           List<Model1> quoteComment = new List<Model1>();
           

           foreach (var item in list)
           {
               string output = "";
               Comment cmt = item;      //获得当前的评论
               List<Comment> quoteList=new List<Comment>();     // 创建当前评论所引用的评论列表
               AddComment(list, quoteList, cmt);    // 为当前评论的引用列表添加项目
               quoteList = quoteList.OrderBy(c => c.Id).ToList();   // 对列表排序，顺序排列
               foreach (Comment quote in quoteList)
               {
                   output = String.Format(
                          "<div>{0}<a>{1}</a><p>{2}</p></div>",
                          output,quote.UserName, quote.Content);
               }
               Model1 model = new Model1();
               model.Id = item.Id;
               model.UserId = item.UserId;
               model.UserName = item.UserName;
               model.Content = item.Content;
               model.CreatTime = item.CreatTime;
               model.CommentId = item.CommentId;
               model.TopicId = item.TopicId;
               model.Status = item.Status;
               model.TopicUserId = item.TopicUserId;
               model.Praise = item.Praise;
               model.quote = output;
               model.UserImg = item.UserImg;

               quoteComment.Add(model);
           }
           ViewBag.quoteComment = quoteComment;
            return PartialView(list);
        }
        #endregion

        #region 显示帖子回复（by 点赞数）
        public ActionResult ShowReplyByPraise(int TopicId)
        {
            var list = CommentService.LoadEntities(c => c.TopicId == TopicId).OrderByDescending(c => c.Praise).ToList();

            List<Model1> quoteComment = new List<Model1>();


            foreach (var item in list)
            {
                string output = "";
                Comment cmt = item;      //获得当前的评论
                List<Comment> quoteList = new List<Comment>();     // 创建当前评论所引用的评论列表
                AddComment(list, quoteList, cmt);    // 为当前评论的引用列表添加项目
                quoteList = quoteList.OrderBy(c => c.Id).ToList();   // 对列表排序，顺序排列
                foreach (Comment quote in quoteList)
                {
                    output = String.Format(
                            "<div>{0}<a>{1}</a><p>{2}</p></div>",
                          output, quote.UserName, quote.Content);
                }
                Model1 model = new Model1();
                model.Id = item.Id;
                model.UserId = item.UserId;
                model.UserName = item.UserName;
                model.Content = item.Content;
                model.CreatTime = item.CreatTime;
                model.CommentId = item.CommentId;
                model.TopicId = item.TopicId;
                model.Status = item.Status;
                model.TopicUserId = item.TopicUserId;
                model.Praise = item.Praise;
                model.quote = output;
                model.UserImg = item.UserImg;
                quoteComment.Add(model);
            }
            ViewBag.quoteComment = quoteComment;
            return PartialView(list);
        }
        #endregion

        #region 为当前评论的引用列表添加项目
        public void AddComment(List<Comment> list, List<Comment> quoteList, Comment cmt)
        {
            if (cmt.CommentId != null)
            {
                Comment find = list.Find(c => c.Id == cmt.CommentId);
                quoteList.Add(find);

                // 递归调用，只要CommentId不为零，就加入到引用评论列表
                AddComment(list, quoteList, find);
            }
            else
                return; 
       
        }
         #endregion

	}
    public class Model1
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public System.DateTime CreatTime { get; set; }
        public Nullable<int> CommentId { get; set; }
        public int TopicId { get; set; }
        public int Status { get; set; }
        public int TopicUserId { get; set; }
        public Nullable<int> Praise { get; set; }
        public string quote { get; set; }
        public string UserImg { get; set; }
    }
}