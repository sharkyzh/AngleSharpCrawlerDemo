using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TswwAngleSharpWeb.Models
{

    /// <summary>
    /// 解析html
    /// </summary>
    public class Agent
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImg { get; set; }
        /// <summary>
        /// 代理名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 累计采购额
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 本月采购额
        /// </summary>
        public string CurrentMothlAmount { get; set; }
        /// <summary>
        /// 首次代理
        /// </summary>
        public string FirstAgentTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public string LastUpDateTime { get; set; }
        /// <summary>
        /// 所属团队
        /// </summary>
        public string BelongTuan { get; set; }
        /// <summary>
        /// 所属团ID
        /// </summary>
        public string TuanIds { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopId { get; set; }
        /// <summary>
        /// 是否更新
        /// </summary>
        public bool IsUpdated { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}