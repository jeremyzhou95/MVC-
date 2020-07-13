using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        //注意补充知识点//Expression,<T>,new()
        IQueryable<T> LoadEntites(System.Linq.Expressions.Expression<Func<T, bool>> wherelambda);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
            System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isASC);
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);
    }
}
