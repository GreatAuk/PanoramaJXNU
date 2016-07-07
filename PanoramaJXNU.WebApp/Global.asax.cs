using log4net;
using PanoramaJXNU.WebApp.Models;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PanoramaJXNU.WebApp
{
    /// <summary>
    /// Application是整个程序的入口
    /// </summary>
    public class MvcApplication : SpringMvcApplication//System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Log4Net的初始化信息，程序开始的时候读取配置文件中关于Log4Net的信息
            log4net.Config.XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //-------------------------------开启线程----------------------------------
            //在开启程序的时候，开启一个线程（这就是为什么这个线程会开启在Global文件里的原因），扫描存储异常信息的队列，当有内容的时候线程工作，没有内容时，休眠一段时间
            //拿到需要存储的物理路径
            string filePath = Server.MapPath("/Log/");
            //开启一个线程池
            ThreadPool.QueueUserWorkItem((a) =>
            {
                //写一个死循环确保线程一致在扫描队列
                while (true)
                {
                    //判断一下队列里是否有数据，有的话写入日志
                    if (MyExceptionAttribute.ExceptionQueue.Count() > 0)
                    {
                        //将队列的数据取出来
                        Exception ex = MyExceptionAttribute.ExceptionQueue.Dequeue();
                        //确保ex有数据，将议程处理的信息存储到日志文件中
                        if (ex != null)
                        {
                            ////将时间作文日志文件名字
                            //string fileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
                            ////将异常信息写入日志文件
                            //File.AppendAllText(filePath + fileName + ".txt", ex.ToString(), System.Text.Encoding.UTF8);

                            //使用Log4Net来记录异常日志文件
                            ILog logger = LogManager.GetLogger("ErrorMes");
                            logger.Error(ex.ToString());
                        }
                        else
                        {
                            Thread.Sleep(3000);//休眠3秒钟
                        }
                    }
                    else//没有的话休眠一段时间在扫描
                    {
                        Thread.Sleep(3000);//休眠3秒钟
                    }
                }

            }, filePath);
        }
    }
}
