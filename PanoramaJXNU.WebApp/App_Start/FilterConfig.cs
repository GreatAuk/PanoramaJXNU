using PanoramaJXNU.WebApp.Models;
using System.Web;
using System.Web.Mvc;

namespace PanoramaJXNU.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//这个是官方的异常处理类
            //注册自己写的异常过滤器
            //filters.Add(new MyExceptionAttribute());

        }
    }
}
