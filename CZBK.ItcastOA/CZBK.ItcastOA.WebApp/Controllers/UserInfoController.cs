using CZBK.ItcastOA.BLL;
using CZBK.ItcastOA.model;
using CZBK.ItcastOA.model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class UserInfoController : BaseController
    {
        // GET: UserInfo
        //IBLL.IUserInfoService userInfoService = new UserInfoService();
        IBLL.IUserInfoService userInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        #region 获取用户列表数据
        public ActionResult GetUserInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 1;
            int totalCount;
            short delFlag = (short)DeleteEnumType.DelFlag.Normal;
            var userInfoList = userInfoService.LoadPageEntities<string>(pageIndex, pageSize, out totalCount, c => c.delFlag == delFlag, c => c.id, true);
            var temp = from u in userInfoList
                       select new
                       {
                           id = u.id,
                           UName = u.userName,
                           UEmail = u.Email,
                           ULogin = u.LoginDate
                       };
            return Json(new { rows = temp, total = totalCount });
        }
        #endregion

        #region 删除用户数据
        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<string> list = new List<string>();
            foreach (var id in strIds)
            {
                list.Add(id);
            }
            if (userInfoService.DeleteEntities(list))
            {
                return Content("OK");
            }
            else
            {
                return Content("Fail");
            }
        }
        #endregion

        #region 添加用户数据
        public ActionResult AdduserInfo(UserInfo userInfo)
        {
            userInfo.delFlag = 0;
            userInfoService.AddEntity(userInfo);
            return Content("OK");
        }

        #endregion

        #region 展示需要修改的用户数据
        public ActionResult ShowEditUserInfo()
        {
            var id = Request["id"];
            var userInfo = userInfoService.LoadEntites(u=>u.id==id).FirstOrDefault();
            return Json(userInfo, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region 编辑用户数据

        public ActionResult EditUserInfo()
        {
            var id = Request["id"];
            var userInfo = userInfoService.LoadEntites(u => u.id == id).FirstOrDefault();
            if (userInfo != null)
            {
                userInfo.id = id;
                userInfo.userName = Request["userName"];
                userInfo.Email = Request["Email"];
                userInfoService.EditEntity(userInfo);
                return Content("OK");
            }
            else
            {
                return Content("Fail");
            }
        }

        #endregion
    }
}