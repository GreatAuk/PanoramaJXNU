using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        IBLL.IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            string Email = Request["LoginEmail"];
            string Password = Request["LoginPwd"];
            //查询数据库
            var userInfo = UserInfoService.LoadEntities(u => u.Email == Email && u.PWord == Password).FirstOrDefault();
            if (userInfo == null)
            {
                return Content("no:账号或密码错误！！");
            }
            Session["UserInfo"] = userInfo;
            return Content("ok");
        }
	}
}