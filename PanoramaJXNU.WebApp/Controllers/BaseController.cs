using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 使用属性的方法保护Session的值
        /// </summary>
        public static string UserInfo
        {
            get
            {
                return System.Web.HttpContext.Current.Session["UserInfo"] != null ? System.Web.HttpContext.Current.Session["UserInfo"].ToString() : string.Empty;
            }
            set
            {
                System.Web.HttpContext.Current.Session["UserInfo"] = value;
            }
        }

        /// <summary>
        /// 重写的OnActionExecuting：在调用方法前先执行这个方法
        /// 让要过滤的控制器先继承于这个方法控制器
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["UserInfo"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
                //当我们在地址栏请求一个地址（例如：/userInfo/Index）时，中间先执行了一个过滤器方法，这里出现了跳转到登录页面的
                //重定向，但是因为每一个控制器下的方法被请求的时候都必须得到一个ActionResult作为返回结果，所以即使执行到重定向的代码时
                //仍然会继续执行，直到获得ActionResult，这样的话不是我们想要的

                filterContext.Result = Redirect("/Login/index");
                //这样的话在执行过滤器方法的时候，已经给请求一个Result结果，这样的话就不必继续执行了，会直接跳转
            }
        }

    }
}