
using System;
using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.Core.Atrributes;

namespace App.Bussiness.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    [LDisplay("用户表"), Table("ts_user")]
    public partial class TsUser
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Required]
        [LDisplay("主键"), Column("ID"), LinqToDB.Mapping.PrimaryKey]
        public virtual string Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(32)]
        [LDisplay("用户名"), Column("C_USERNAME")]
        public virtual string CUsername { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [LDisplay("密码"), Column("C_PASSWORD")]
        public virtual string CPassword { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [Required]
        [StringLength(32)]
        [LDisplay("用户类型"), Column("C_USERTYPE")]
        public virtual decimal? CUserType { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [StringLength(32)]
        [LDisplay("电话号码"), Column("C_PHONE")]
        public virtual string CPhone { get; set; }

        /// <summary>
        /// N禁用Y启用
        /// </summary>
        [Display(Name = "N禁用Y启用"), Column("C_ENABLE")]
        public virtual string CEnable { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        [Display(Name = "公司Id"), Column("C_COMPANY")]
        public virtual string CCompany { get; set; }


        /// <summary>
        /// 登录SessionID
        /// </summary>
        [Display(Name = "登录SessionID"), Column("C_SESSION_ID", Length = 32)]
        public virtual string CSessionId { get; set; }
        /// <summary>
        /// 只允许一个客户端登陆
        /// </summary>
        [Display(Name = "只允许一个客户端登录"), Column("C_ONLY_ONE_CLIENT", Length = 32)]
        public virtual string COnlyOneClient
        {
            get;
            set;
        }
        /// <summary>
        /// 登陆IP地址
        /// </summary>
        [Display(Name = "登陆IP地址"), Column("C_LOGINED_IP", Length = 32)]
        public virtual string CLoginedIp
        {
            get;
            set;
        }
        /// <summary>
        /// 登陆主机名
        /// </summary>
        [Display(Name = "登陆主机名"), Column("C_LOGINED_MACHINE", Length = 512)]
        public virtual string CLoginedMachine
        {
            get;
            set;
        }
        /// <summary>
        /// 登陆时间
        /// </summary>
        [Display(Name = "登录时间"), Column("D_LOGINED_TIME")]
        public virtual DateTime? DLoginedTime
        {
            get;
            set;
        }
        /// <summary>
        /// Session更新时间
        /// </summary>
        [Display(Name = "Session更新时间"), Column("D_SESSION_UPDATE_TIME")]
        public virtual DateTime? DSessionUpdateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        [Display(Name = "时间戳"), Column("C_TIMESTAMP")]
        public virtual DateTime? TimeStamp
        {
            get;
            set;
        }

        = DateTime.Now;

        /// <summary>
        /// 登录超时验证
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool IsSessionTimeout(int timeout)
        {
            return (DateTime.Now - this.DSessionUpdateTime.GetValueOrDefault()).TotalMinutes > (double)timeout;
        }
    }
}