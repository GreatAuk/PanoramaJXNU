using PanoramaJXNU.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.DALFactory
{
    /// <summary>
    /// 直接new,导致重复创建DBSession的实例，导致上下文不一致，保证线程内唯一
    /// 方法：CallContext
    /// </summary>
    public class DBSessionFactory
    {
        private static string key = "DBSession-Single";

        public static IDBSession InstanceDBSession
        {
            get
            {
                IDBSession temp = CallContext.GetData(key) as IDBSession;
                if (temp == null)
                {
                    temp = new DBSession();
                    CallContext.SetData(key, temp);
                }
                return temp;
            }
            private set { }
        }
    }
}
