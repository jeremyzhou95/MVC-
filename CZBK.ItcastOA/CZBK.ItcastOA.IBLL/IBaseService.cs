using CZBK.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        IDBSession CurrentDBSession { get; }
        IDAL.IBaseDal<T> CurrentDal { get; set; }
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);
        IQueryable<T> LoadEntites(System.Linq.Expressions.Expression<Func<T, bool>> wherelambda);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isASC);
    }
}
