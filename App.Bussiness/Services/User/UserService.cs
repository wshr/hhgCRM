using App.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bussiness.Entities;
using App.Bussiness.Helpers;
using App.Bussiness.Extensions;
using LinqToDB;

namespace App.Bussiness.Service
{
    public class UserService : AppService<UserService>
    {

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public virtual void Register(string username, string password, string phone, string compid)
        {
            if (GetUserByUserId(username) == null)
            {
                TsUser user = new TsUser
                {
                    Id = username,
                    CPassword = SimpleCipherHelper.Instance.MD5EncryptWithSalt(password, "rvmob"),
                    CPhone = phone,
                    CCompany = compid,
                    CEnable = "Y"
                };
                GetDbContext().Insert(user);
            }
            else
            {
                throw new Exception("用户名被占用，请重新输入！");
            }

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual TsUser Login(string username, string password)
        {
            var tsUser = GetDbContext().GetTable<TsUser>().FirstOrDefault(x => x.Id.Equals(username));
            if (tsUser == null)
            {
                throw new Exception("用户账户不存在，请检查！");
            }
            string b = SimpleCipherHelper.Instance.MD5EncryptWithSalt(password, "rvmob");
            if (tsUser.CPassword != b)
            {
                throw new Exception("密码错误，请检查！");
            }
            if (!tsUser.CEnable.IsTrue())
            {
                throw new Exception("用户已禁用，请联系管理员！");
            }
            //session 为空或超时情况下重新设定session
            bool flag5 = (string.IsNullOrEmpty(tsUser.CSessionId) || tsUser.COnlyOneClient.IsTrue() || tsUser.IsSessionTimeout(720));
            if (flag5)
            {
                //获取SessionId
                tsUser.CSessionId = Guid.NewGuid().ToString("N").ToUpper();
            }
            //记录登录时间
            UpdateWhileLogin(tsUser.Id, tsUser.CSessionId);

            return tsUser;
        }

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

        /// <summary>
        /// 根据Id查询用户
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public virtual TsUser GetUserByUserId(string userid)
        {
            return GetDbContext().GetTable<TsUser>()
                .FirstOrDefault(x => x.Id.Equals(userid));
        }

        /// <summary>
        /// 登录后更新用户
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="token"></param>
        private void UpdateWhileLogin(string userid, string token)
        {
            GetDbContext().GetTable<TsUser>()
                .Where(x => x.Id.Equals(userid))
                .Set(x => x.CSessionId, token)
                .Set(x => x.DLoginedTime, DateTime.Now)
                .Set(x => x.DSessionUpdateTime, DateTime.Now)
                .Update();
        }

        /// <summary>
        /// 修改用户名密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newpass"></param>
        /// <param name="oldpass"></param>
        public virtual int UpdateTsUserPassword(string token, string newpass, string oldpass)
        {
            var tsUser = GetTsUserByToken(token);
            string b = SimpleCipherHelper.Instance.MD5EncryptWithSalt(oldpass, "rvmob");
            if (tsUser.CPassword != b)
            {
                throw new Exception("原始密码错误，请检查！");
            }
            //更新密码
            return GetDbContext().GetTable<TsUser>()
                 .Where(x => x.Id.Equals(tsUser.CUsername))
                 .Update(x => new TsUser
                 {
                     CPassword = SimpleCipherHelper.Instance.MD5EncryptWithSalt(newpass, "rvmob")
                 });

        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        public virtual void UpdateTsUser(TsUser user)
        {
            GetDbContext().Update(user);
        }


    }
}
