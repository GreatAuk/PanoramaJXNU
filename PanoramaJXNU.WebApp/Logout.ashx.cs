using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanoramaJXNU.WebApp
{
    using System.Web.Mvc;

    using System.Web.SessionState;
    using PanoramaJXNU.Model;
    /// <summary>
    /// Logout 的摘要说明
    /// </summary>
    public class Logout : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session["UserInfo"] = null;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}