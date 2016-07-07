using PanoramaJXNU.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.DAL
{
    /// <summary>
    /// DbContext实例化的工厂,避免重复创建DbContext的实例，导致上下文不一致，保证线程内唯一
    /// </summary>
    public class DbContextFactory
    {
        ///使用属性的方式创建DbContext的实例化对象
        static string key = "DbContext-Single";
        public static DbContext InstanceDbContext
        {
            get
            {
                DbContext temp = CallContext.GetData(key) as DbContext;
                if (temp == null)
                {
                    temp = new Panorama_JXNUEntities();
                    CallContext.SetData(key, temp);
                }
                return temp;
            }
            private set { }
        }
    }
}
