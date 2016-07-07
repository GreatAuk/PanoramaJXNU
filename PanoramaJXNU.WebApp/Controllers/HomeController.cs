using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.IBLL;
    using PanoramaJXNU.Model;
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        IPanoPraiseRecordService PanoPraiseRecordService { get; set; }
        IPanoCollectService PanoCollectService { get; set; }
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
            return View();
        }

        #region 全景点赞
        public ActionResult PanoPraise(PanoPraiseRecord panoPraiseRecord, string PanoHtml)
        {
           
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            int userid= ((UserInfo)Session["UserInfo"]).UserId;

            PanoPraiseRecord p = PanoPraiseRecordService.LoadEntities(c => c.UserId == userid && c.panoHtml == PanoHtml).FirstOrDefault();
            if(p!=null)
            {
                return Content("no");
            }
            panoPraiseRecord.UserId = userid;
            panoPraiseRecord.panoHtml = PanoHtml;
            panoPraiseRecord.Time = System.DateTime.Now;
            PanoPraiseRecordService.AddEntity(panoPraiseRecord);
            return Content("ok");
        }
        #endregion
        #region 全景收藏
        public ActionResult Collect(PanoCollect panoCollect, string PanoHtml)
        {
            if (Session["UserInfo"] == null)
            {
                return Content("请先登录");
            }
            int userid = ((UserInfo)Session["UserInfo"]).UserId;
            PanoCollect p = PanoCollectService.LoadEntities(c => c.UserId == userid && c.panoHtml == PanoHtml).FirstOrDefault();
            if (p != null)
            {
                return Content("no");
            }
            panoCollect.UserId = userid;
            panoCollect.CollectTime = System.DateTime.Now;
            panoCollect.panoHtml = PanoHtml;
            PanoCollectService.AddEntity(panoCollect);
            return Content("ok");
        }
        #endregion
        public ActionResult Pano02()
        {
            if (Session["UserInfo"] == null)
            {
                ViewBag.headImg = "None";
            }
            else
            {
                ViewBag.headImg = ((UserInfo)Session["UserInfo"]).HeadImg;
            }
            return View();
        }
        public ActionResult Pano03()
        {
            return View();
        }
        public ActionResult Pano04()
        {
            return View();
        }
        public ActionResult Pano05()
        {
            return View();
        }
        public ActionResult Pano06()
        {
            return View();
        }
        public ActionResult Pano07()
        {
            return View();
        }
        public ActionResult Pano08()
        {
            return View();
        }
        public ActionResult Pano09()
        {
            return View();
        }
        public ActionResult Pano10()
        {
            return View();
        }
        public ActionResult Pano11()
        {
            return View();
        }
        public ActionResult Pano12()
        {
            return View();
        }
        public ActionResult Pano13()
        {
            return View();
        }
        public ActionResult Pano14()
        {
            return View();
        }
        public ActionResult Pano15()
        {
            return View();
        }
        public ActionResult Pano16()
        {
            return View();
        }
        public ActionResult Pano17()
        {
            return View();
        }
        public ActionResult Pano18()
        {
            return View();
        }
        public ActionResult Pano19()
        {
            return View();
        }
        public ActionResult Pano20()
        {
            return View();
        }
        public ActionResult Pano21()
        {
            return View();
        }
        public ActionResult Pano22()
        {
            return View();
        }
        public ActionResult Pano23()
        {
            return View();
        }
        public ActionResult Pano24()
        {
            return View();
        }
	}
}