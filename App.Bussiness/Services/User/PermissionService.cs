using App.Bussiness.Entities;
using App.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Bussiness.Services.User
{
    public class PermissionService : AppService<PermissionService>
    {

        /// <summary>
        /// 根据Token获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual TsUser GetTsUserByToken(string token)
        {
            TsUser tsUser = GetDbContext().GetTable<TsUser>()
                .FirstOrDefault(x => x.CSessionId.Equals(token));
            if (tsUser == null)
            {
                throw new Exception("Token 错误，用户登录失效或用户不存在！");
            }
            return tsUser;
        }



    }
}
