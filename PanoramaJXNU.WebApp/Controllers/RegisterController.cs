using PanoramaJXNU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        IBLL.IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRegister(UserInfo userInfo)
        {
            //获取用户填写的表单数据
            userInfo.PWord = Request["password"];
            string passwordConfirm = Request["PwdConfirm"];
            userInfo.UserName = Request["UserName"];
            userInfo.Email = Request["Email"];
            userInfo.Gender = "男";
            userInfo.DelFlag = 0;
            userInfo.City = "未知";
            userInfo.TopicCount = 0;
            userInfo.Signature = "这个家伙很懒，什么都没有留下！";
            userInfo.HeadImg = "/Content/head/default.gif";
            userInfo.Topic = null;
            userInfo.Status = 0;
            userInfo.RegTime = DateTime.Now;
            userInfo.DataLastLogin = DateTime.Now;

            UserInfoService.AddEntity(userInfo);
            return Content("ok");
        }
	}
}