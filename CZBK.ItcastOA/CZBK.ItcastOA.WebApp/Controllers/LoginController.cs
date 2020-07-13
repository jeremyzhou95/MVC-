using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CZBK.ItcastOA.Common;
using CZBK.ItcastOA.model;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        IBLL.IUserInfoService userInfoService { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        #region 完成用户登录
        public ActionResult UserLogin()
        {
            string validateCode = Session["validateCode"] != null ? Session["validateCode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!!");
            }
            Session["validateCode"] = null;
            string txt_Code = Request["vCode"];
            if (!validateCode.Equals(txt_Code, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            var userInfo = userInfoService.LoadEntites(u => u.userName == userName & u.userPwd==userPwd).FirstOrDefault();
            if (userInfo != null)
            {
                Session["userInfo"] = userInfo;
                return Content("ok:登录成功");
            }
            else
            {
                return Content("no:登录失败");
            }
        }

        #endregion

        #region 显示验证码
        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["validateCode"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);//把验证码画在画布上并转为Byte字节
            return File(buffer, "image/jpeg");
        }
        #endregion
    }
}