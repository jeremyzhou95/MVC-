using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using CZBK.ItcastOA.model;

namespace CZBK.ItcastOA.DAL
{
    /// <summary>
    /// 负责创建EF数据创建上下文实例，保证线程内唯一
    /// </summary>
    public class DBContextFactory
    {
        public static DbContext CreateDBContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new OAEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
