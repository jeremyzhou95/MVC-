using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserInfoDal;
        }

        public bool DeleteEntities(List<string> list)
        {
            var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntites(u => list.Contains(u.id));
            foreach (var userInfo in userInfoList)
            {
                this.CurrentDBSession.UserInfoDal.DeleteEntity(userInfo);
            }
            return this.CurrentDBSession.SaveChange();
        }
    }
}
