using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp.Models
{
    public class MyExceptionAttribute : HandleErrorAttribute
    {
        //声明一个先进先出的队列存储异常信息
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();

        /// <summary>
        /// 重写HandleErrorAttribute里的虚方法OnException
        /// 当发生异常时调用此方法
        /// </summary>
        /// <param name="filterContext">异常过滤器的上下文 </param>
        public override void OnException(ExceptionContext filterContext)
        {

            //1.获取异常信息
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            //2、将异常信息存储到队列（存储到队列的好处？？）
            ExceptionQueue.Enqueue(ex);
            //3、转到到统一异常处理信息页面
            filterContext.HttpContext.Response.Redirect("/Error404.htm");
        }
    }
}