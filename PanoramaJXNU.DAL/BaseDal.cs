using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.DAL
{
    /// <summary>
    /// 数据访问层基类
    /// </summary>
    public class BaseDal<T> where T : class,new()
    {
        //MVC04OAEntities DB = new MVC04OAEntities();//直接new的情况，这是一个封装点
        DbContext DB = DbContextFactory.InstanceDbContext;
        //增
        public T AddEntity(T entity)
        {
            
            //EntityFramework
            //打上添加标记，然后保存
            DB.Set<T>().Add(entity);//某某数据库下的某某数据集,完整定义了保存到哪里
            //DB.SaveChanges();

            return entity;
        }
        //删
        public bool DeleteEntity(T entity)
        {
            DB.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            //return DB.SaveChanges() > 0;
            return true;
        }
        //改
        public bool EditEntity(T entity)
        {
            DB.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            //return DB.SaveChanges() > 0;
            return true;
        }
        //查
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return DB.Set<T>().Where<T>(whereLambda);
        }
        //连表查询
        public IQueryable<T> LoadEntitiesJoin(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,string IncludeTable)
        {
            DbQuery<T> reslist = DB.Set<T>();  //可以将子类赋值给父类
            reslist = DB.Set<T>().Include(IncludeTable);
            return reslist.Where<T>(whereLambda);
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
            //首先查询一下
            var temp = DB.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            //分页
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, S>(OrderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);

            }
            else//降序
            {
                temp = temp.OrderByDescending<T, S>(OrderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);

            }
            return temp;
        }
    }
}
