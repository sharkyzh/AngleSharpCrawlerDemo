using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TswwAngleSharpWeb.Models
{
    public class Tuan
    {
        public long Id { get; set; }
        /// <summary>
        /// 团ID
        /// </summary>
        public string TuanId { get; set; }
        /// <summary>
        /// 团队图标
        /// </summary>
        public string HeadImg { get; set; }
        /// <summary>
        /// 团队名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 团人数
        /// </summary>
        public string TuanRenShu { get; set; }
        /// <summary>
        /// 团队类型
        /// </summary>
        public string TuanType { get; set; }
        /// <summary>
        /// 团队人数
        /// </summary>
        public string TuanZhang { get; set; }
        /// <summary>
        /// 饭店模式
        /// </summary>
        public string FanLiType { get; set; }
        /// <summary>
        /// 累计成交额
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 累计成交量
        /// </summary>
        public string TotalSaleCount { get; set; }
        /// <summary>
        /// 团队创建时间
        /// </summary>
        public string TuanCreateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否已更新
        /// </summary>
        public bool IsUpdate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}