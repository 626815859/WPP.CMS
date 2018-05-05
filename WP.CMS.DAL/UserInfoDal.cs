using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.CMS.Model;

namespace WP.CMS.DAL
{
    //继承基类BaseDal共有的方法
    public class UserInfoDal: BaseDal<UserInfo>
    {
        //自己特有的方法

            /// <summary>
            /// 查找到用户
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="userPwd"></param>
            /// <returns></returns>
        public UserInfo GetUserInfo(string userName, string userPwd)
        {
            return Db.Set<UserInfo>().Where(u => u.UserName == userName && u.UserPwd == userPwd).SingleOrDefault();
        }

    }
}
