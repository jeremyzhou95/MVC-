using CZBK.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.ItcastOA.DAL;
using CZBK.ItcastOA.model;
using System.Data.Entity;

namespace CZBK.ItcastOA.DALFactory
{
    public class DBSession : IDBSession
    {
        public DbContext Db
        {
            get
            {
                return DBContextFactory.CreateDBContext();
            }
        }
        /// <summary>
        /// 数据会话层:工厂类
        /// </summary>
        /// <returns></returns>
        private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_UserInfoDal == null)
                {
                    _UserInfoDal = AbstarctFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }

            set
            {
                _UserInfoDal = value;
            }
        }
        public bool SaveChange()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
