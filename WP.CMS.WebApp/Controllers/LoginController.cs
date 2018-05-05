using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WP.CMS.BLL;
using WP.CMS.Model;

namespace Iotzzh.CMS.Webapp.Controllers
{
    public class LoginController : Controller
    {
        UserInfoService userInfoService = new UserInfoService();
        //约定大于配置
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 注册页1
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRegister()
        {
            return View();
        }
        /// <summary>
        /// 注册页2
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserRegister(UserInfo userInfo)
        {
            userInfo.RegTime = DateTime.Now;
            if(userInfoService.Add(userInfo)==true)
            {
                return Content("<script>alert('注册成功。');window.location.href='/Login/Index'</script>");
                // return RedirectToAction("Index");  //重定向到Home Index
            }
            else
            {
                return View("UserRegister");
            }
            
        }


        //通过Ajax获取前台传入的数据
        public ActionResult UserLogin()
        {
            //首先判断已给的验证处是否为空
            string validateCode = Session["code"] == null ? string.Empty :
                Session["code"].ToString();
            //如果已给的验证码为空，提示！
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误");
            }
            //此时的session已经赋值给了validateCode，所以可以清空了
            Session["code"] = null;
            //获取用户输入的验证码
            string txtCode = Request["vCode"];
            //判断，如果系统的验证码与用户输入的验证码不一致，则提示
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
          //  UserInfoService userInfoService = new UserInfoService();
            UserInfo userInfo = userInfoService.GetUserInfo(userName, userPwd);
            if (userInfo != null)
            {
                Session["userInfo"] = userInfo;
                return Content("ok:登录成功!");
            }
            else
            {
                return Content("no:登录失败！");
            }


        }
        //调用分装验证码的类
        public ActionResult ShowValidateCode()
        {
            WP.CMS.Common.ValidateCode validateCode = new WP.CMS.Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);//获取验证码长度.
            Session["code"] = code;//存入与用户输入进行校验
            byte[] buffer = validateCode.CreateValidateGraphic(code);  //创建图片
            return File(buffer, "image/jpeg");
        }
    }
}
