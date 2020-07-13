using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DALFactory
{
    public class DBSessionFactory
    {
        public static IDAL.IDBSession CreateDBSession()
        {
            IDAL.IDBSession DBSession = (IDAL.IDBSession)CallContext.GetData("DBSession");
            if (DBSession == null)
            {
                DBSession = new DBSession();
                CallContext.SetData("DBSession",DBSession);
            }
            return DBSession;
        }
    }
}
