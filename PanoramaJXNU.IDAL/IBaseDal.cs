using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaJXNU.IDAL
{

    /// <summary>
    /// 数据访问层的基类接口
    /// "T"是具体操作的【数据集】实体
    /// </summary>
    public interface IBaseDal<T> where T : class,new()
    {
        //增
        T AddEntity(T entity);
        //删
        bool DeleteEntity(T entity);
        //改
        bool EditEntity(T entity);
        //查
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        //连表查询
        IQueryable<T> LoadEntitiesJoin(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, string IncludeTable);
        //分页
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
            System.Linq.Expressions.Expression<Func<T, S>> OrderbyLambda,
            bool isAsc
            );
    }

}
