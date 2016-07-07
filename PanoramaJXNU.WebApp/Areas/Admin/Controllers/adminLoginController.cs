using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Areas.Admin.Controllers
{
    using PanoramaJXNU.Model;
    using PanoramaJXNU.IBLL;
    public class adminLoginController : Controller
    {
        IAdminsService AdminsService { set; get; }
        //
        // GET: /Admin/Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Check(Admins model)
        {
            string username = model.UserName;
            string password = model.PassWords;

            Admins admin = AdminsService.LoadEntities(c => c.UserName == username&&c.PassWords==password).FirstOrDefault();
            if (admin != null)
            {
                Session["admin"] = username;
                return Content("ok!");
            }
            else
            {
                return Content("no");
            }
            
        }
      
	}
}