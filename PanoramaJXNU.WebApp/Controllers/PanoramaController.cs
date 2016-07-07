using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.Model;
    public class PanoramaController : Controller
    {
       
        //
        // GET: /Panorama/
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
	}
}