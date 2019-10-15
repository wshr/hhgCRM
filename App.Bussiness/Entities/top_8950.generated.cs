
using System;
using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.Core.Atrributes;

namespace App.Bussiness.Entities
{
    /// <summary>
    /// 在制品收发存表
    /// </summary>
    [Serializable]
    [LDisplay("在制品收发存表"), Table("TOP_8950")]
    public partial class Top8950 
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Required]
        [LDisplay("主键"), Column("C_ID"), LinqToDB.Mapping.PrimaryKey]
        public virtual string Id { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(32)]
        [LDisplay("创建人"), Column("C_CREATOR")]
        public virtual string Creator { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        [LDisplay("创建时间"), Column("D_CREATE_TIME")]
        public virtual DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(32)]
        [LDisplay("修改人"), Column("C_LAST_MODIFIER")]
        public virtual string LastModifier { get; set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        [LDisplay("修改时间"), Column("D_LAST_MODIFY_TIME")]
        public virtual DateTime? LastModifyTime { get; set; }
        
        /// <summary>
        /// 工厂
        /// </summary>
        [Required]
        [StringLength(32)]
        [LDisplay("工厂"), Column("C_PLANT_ID")]
        public virtual string CPlantId { get; set; }
        
        /// <summary>
        /// 年月
        /// </summary>
        [Required]
        [StringLength(32)]
        [LDisplay("年月"), Column("C_YEAR_MONTH")]
        public virtual string CYearMonth { get; set; }
        
        /// <summary>
        /// 纸种
        /// </summary>
        [Required]
        [StringLength(32)]
        [LDisplay("纸种"), Column("C_PAPER_GROW")]
        public virtual string CPaperGrow { get; set; }
        
        /// <summary>
        /// 克重
        /// </summary>
        [Required]
        [LDisplay("克重"), Column("N_GRAM_WGT")]
        public virtual decimal NGramWgt { get; set; }
        
        /// <summary>
        /// 月末平板产出未入库
        /// </summary>
        [LDisplay("月末平板产出未入库"), Column("N_YMPB")]
        public virtual decimal? NYmpb { get; set; }
        
        /// <summary>
        /// 月末卷筒产出未入库
        /// </summary>
        [LDisplay("月末卷筒产出未入库"), Column("N_YMJT")]
        public virtual decimal? NYmjt { get; set; }
        
        /// <summary>
        /// 平板投大于产
        /// </summary>
        [LDisplay("平板投大于产"), Column("N_PBCDYT")]
        public virtual decimal? NPbcdyt { get; set; }
        
        /// <summary>
        /// 期初卷
        /// </summary>
        [LDisplay("期初卷"), Column("N_QCJ")]
        public virtual decimal? NQcj { get; set; }
        
        /// <summary>
        /// 期初平
        /// </summary>
        [LDisplay("期初平"), Column("N_QCP")]
        public virtual decimal? NQcp { get; set; }
        
        /// <summary>
        /// 期初平纸垛
        /// </summary>
        [LDisplay("期初平纸垛"), Column("N_QCPZD")]
        public virtual decimal? NQcpzd { get; set; }
        
        /// <summary>
        /// 投入卷
        /// </summary>
        [LDisplay("投入卷"), Column("N_TRJ")]
        public virtual decimal? NTrj { get; set; }
        
        /// <summary>
        /// 投入平
        /// </summary>
        [LDisplay("投入平"), Column("N_TRP")]
        public virtual decimal? NTrp { get; set; }
        
        /// <summary>
        /// 投入平小复卷
        /// </summary>
        [LDisplay("投入平小复卷"), Column("N_TRPJ")]
        public virtual decimal? NTrpj { get; set; }
        
        /// <summary>
        /// 投入平平板
        /// </summary>
        [LDisplay("投入平平板"), Column("N_TRPP")]
        public virtual decimal? NTrpp { get; set; }
        
        /// <summary>
        /// 产出卷
        /// </summary>
        [LDisplay("产出卷"), Column("N_CCJ")]
        public virtual decimal? NCcj { get; set; }
        
        /// <summary>
        /// 产出平
        /// </summary>
        [LDisplay("产出平"), Column("N_CCP")]
        public virtual decimal? NCcp { get; set; }
        
        /// <summary>
        /// 损纸卷
        /// </summary>
        [LDisplay("损纸卷"), Column("N_SZJ")]
        public virtual decimal? NSzj { get; set; }
        
        /// <summary>
        /// 损纸平
        /// </summary>
        [LDisplay("损纸平"), Column("N_SZP")]
        public virtual decimal? NSzp { get; set; }
        
        /// <summary>
        /// 判入卷
        /// </summary>
        [LDisplay("判入卷"), Column("N_PRJ")]
        public virtual decimal? NPrj { get; set; }
        
        /// <summary>
        /// 判入平
        /// </summary>
        [LDisplay("判入平"), Column("N_PRP")]
        public virtual decimal? NPrp { get; set; }
        
        /// <summary>
        /// 判出卷
        /// </summary>
        [LDisplay("判出卷"), Column("N_PCJ")]
        public virtual decimal? NPcj { get; set; }
        
        /// <summary>
        /// 判出平
        /// </summary>
        [LDisplay("判出平"), Column("N_PCP")]
        public virtual decimal? NPcp { get; set; }
        
        /// <summary>
        /// 改去向入卷
        /// </summary>
        [LDisplay("改去向入卷"), Column("N_GRJ")]
        public virtual decimal? NGrj { get; set; }
        
        /// <summary>
        /// 改去向入平
        /// </summary>
        [LDisplay("改去向入平"), Column("N_GRP")]
        public virtual decimal? NGrp { get; set; }
        
        /// <summary>
        /// 改去向出卷
        /// </summary>
        [LDisplay("改去向出卷"), Column("N_GCJ")]
        public virtual decimal? NGcj { get; set; }
        
        /// <summary>
        /// 改去向出平
        /// </summary>
        [LDisplay("改去向出平"), Column("N_GCP")]
        public virtual decimal? NGcp { get; set; }
        
        /// <summary>
        /// 系统期末卷
        /// </summary>
        [LDisplay("系统期末卷"), Column("N_XTQMJ")]
        public virtual decimal? NXtqmj { get; set; }
        
        /// <summary>
        /// 系统期末平
        /// </summary>
        [LDisplay("系统期末平"), Column("N_XTQMP")]
        public virtual decimal? NXtqmp { get; set; }
        
        /// <summary>
        /// 系统期末平纸垛
        /// </summary>
        [LDisplay("系统期末平纸垛"), Column("N_XTQMPZD")]
        public virtual decimal? NXtqmpzd { get; set; }
        
        /// <summary>
        /// 平板产未传出量
        /// </summary>
        [LDisplay("平板产未传出量"), Column("N_PBCWCCL")]
        public virtual decimal? NPbcwccl { get; set; }
        
        /// <summary>
        /// 卷筒产未传出量
        /// </summary>
        [LDisplay("卷筒产未传出量"), Column("N_JTCWCCL")]
        public virtual decimal? NJtcwccl { get; set; }
        
        /// <summary>
        /// 小复卷损纸
        /// </summary>
        [LDisplay("小复卷损纸"), Column("N_XFJSZ")]
        public virtual decimal? NXfjsz { get; set; }
        
        /// <summary>
        /// 裁切损纸
        /// </summary>
        [LDisplay("裁切损纸"), Column("N_CQSZ")]
        public virtual decimal? NCqsz { get; set; }
        
        /// <summary>
        /// 改切损纸
        /// </summary>
        [LDisplay("改切损纸"), Column("N_GQSZ")]
        public virtual decimal? NGqsz { get; set; }
        
        /// <summary>
        /// 选理损纸
        /// </summary>
        [LDisplay("选理损纸"), Column("N_XLSZ")]
        public virtual decimal? NXlsz { get; set; }
        
        /// <summary>
        /// 备用
        /// </summary>
        [StringLength(32)]
        [LDisplay("备用"), Column("C_BAK01")]
        public virtual string CBak01 { get; set; }
        
        /// <summary>
        /// 备用
        /// </summary>
        [LDisplay("备用"), Column("N_BAK01")]
        public virtual decimal? NBak01 { get; set; }
        
        /// <summary>
        /// 备用
        /// </summary>
        [StringLength(4000)]
        [LDisplay("备用"), Column("C_BAK02")]
        public virtual string CBak02 { get; set; }
        
        /// <summary>
        /// 备用
        /// </summary>
        [LDisplay("备用"), Column("N_BAK02")]
        public virtual decimal? NBak02 { get; set; }
        
    }
}