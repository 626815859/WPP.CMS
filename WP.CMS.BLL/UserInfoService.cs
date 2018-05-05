using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.CMS.DAL;
using WP.CMS.Model;

namespace WP.CMS.BLL
{
    public class UserInfoService : BaseService<UserInfo>
    {
        private UserInfoDal UserInfoDAL = new UserInfoDal();
        public override void SetDal()
        {
            Dal = UserInfoDAL;
        }
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string userName,string userPwd)
        {
            return UserInfoDAL.GetUserInfo(userName, userPwd);
        }
    }
}
