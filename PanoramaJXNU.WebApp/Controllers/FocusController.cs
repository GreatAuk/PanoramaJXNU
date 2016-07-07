using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IBLL;
    public class FocusController : Controller
    {
        IFocusService FocusService { get; set; }
        //
        // GET: /Focus/
        public ActionResult focus(string focusname)
        {
            
            Focus focus=new Focus();
            focus.UserName = ((UserInfo)Session["UserInfo"]).UserName;
            focus.FriendName = focusname;
            FocusService.AddEntity(focus);
            return Content("ok");
        }
	}
}