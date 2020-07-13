using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.ItcastOA.IDAL;
using CZBK.ItcastOA.DALFactory;
using CZBK.ItcastOA.IBLL;

namespace CZBK.ItcastOA.BLL
{
    public abstract class BaseService<T>:IBaseService<T> where T : class, new()
    {
        public BaseService()
        {
            SetCurrentDal();
        }
        public IDAL.IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();
        public IDBSession CurrentDBSession
        {
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }

        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return CurrentDBSession.SaveChange();
        }
        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CurrentDBSession.SaveChange();
        }
        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            CurrentDBSession.SaveChange();
            return entity;
        }
        public IQueryable<T> LoadEntites(System.Linq.Expressions.Expression<Func<T, bool>> wherelambda)
        {
            return CurrentDal.LoadEntites(wherelambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isASC)
        {
            return CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isASC);
        }
    }
}
