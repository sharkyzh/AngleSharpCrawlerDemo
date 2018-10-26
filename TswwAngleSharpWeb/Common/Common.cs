using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TswwAngleSharpWeb
{
    public class Common
    {
        #region 获取登录帐号密码
        /// <summary>
        /// 获取登录帐号密码
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<String, String>> GetPostPara()
        {
            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
            paramList.Add(new KeyValuePair<string, string>("mobile", ""));
            paramList.Add(new KeyValuePair<string, string>("password", ""));
            return paramList;
        }
        #endregion
    }
}