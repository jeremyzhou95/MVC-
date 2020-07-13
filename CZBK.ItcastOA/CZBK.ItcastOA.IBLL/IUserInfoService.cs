using CZBK.ItcastOA.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IBLL
{
    public interface IUserInfoService:IBaseService<UserInfo>
    {
        bool DeleteEntities(List<string> list);
    }
}
