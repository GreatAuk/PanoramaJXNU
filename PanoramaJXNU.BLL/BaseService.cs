using PanoramaJXNU.DALFactory;
using PanoramaJXNU.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.BLL
{
    /// <summary>
    /// 业务逻辑层基类，实现增删改查分页基本操作，该类将调用DAl层的数据访问基类
    /// </summary>
    public abstract class BaseService<T> where T : class,new()
    {
        //创建DBSession的对象
        private IDBSession _CreateDBSession;

        public IDBSession CreateDBSession
        {
            get
            {
                if (_CreateDBSession == null)
                {
                    //_CreateDBSession = new DBSession();//直接new,导致重复创建DBSession的实例，导致上下文不一致，保证线程内唯一
                    _CreateDBSession = DBSessionFactory.InstanceDBSession;
                }
                return _CreateDBSession;
            }
            set { _CreateDBSession = value; }
        }

        public IBaseDal<T> CurrentDal { get; set; }//自动属性
        public abstract void SetCurrentDal();//抽象方法，继承这个类的方法必须实现这个抽象方法
        public BaseService()
        {
            SetCurrentDal();//子类一定要实现这个方法，来指定是哪一个具体的操作类，调用的时候才能传递过来
        }


        //增
        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);//这是基类，并不知道数据操作类是哪一个，这个问题需要解决
            CreateDBSession.SaveChanges();//调用DBSession的SaveChanges()的方法保存数据
            return entity;

        }

        //删
        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return CreateDBSession.SaveChanges();
        }
        //改
        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CreateDBSession.SaveChanges();
        }
        //查
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }
         //连表查询
        public IQueryable<T> LoadEntitiesJoin(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, string IncludeTable)
        {
            return CurrentDal.LoadEntitiesJoin(whereLambda, IncludeTable);
        }
        //分页
        public IQueryable<T> LoadPageEntities<S>(
            int pageIndex,
            int pageSize,
            out int totalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
            System.Linq.Expressions.Expression<Func<T, S>> OrderbyLambda,
            bool isAsc
            )
        {
            return CurrentDal.LoadPageEntities<S>(pageIndex, pageSize, out totalCount, whereLambda, OrderbyLambda, isAsc);
        }
    }
}
