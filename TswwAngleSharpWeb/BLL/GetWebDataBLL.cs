using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AngleSharp.Parser.Html;
using TswwAngleSharpWeb.Models;

namespace TswwAngleSharpWeb.BLL
{
    public class GetWebDataBLL
    {
        #region 获取代理列表并写入数据库

        /// <summary>
        /// 获取代理列表并写入数据库
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="maxPage"></param>
        /// <param name="loginUrl"></param>
        /// <param name="baseUrl"></param>
        public static async Task GetAgentList(int startPage, int maxPage, string loginUrl, string baseUrl)
        {
            CookieContainer cookiescontainer = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                CookieContainer = cookiescontainer,
                AllowAutoRedirect = true,
                UseCookies = true
            };
            var httpClient = new HttpClient(handler);
            var result = await httpClient.PostAsync(loginUrl, new FormUrlEncodedContent(Common.GetPostPara()));
            if (result.IsSuccessStatusCode)
            {
                var parser = new HtmlParser();
                for (int i = startPage; i <= maxPage; i++)
                {
                    var pageResult = await httpClient.GetStringAsync($"http://sp.wdwd.com/distr/lists?p={i}");
                    var document = await parser.ParseAsync(pageResult);
                    var tbodyTrs = document.QuerySelectorAll("tbody");
                    var trElements = tbodyTrs[0].QuerySelectorAll("tr");
                    List<Agent> agentList = new List<Agent>();
                    foreach (var item in trElements)
                    {
                        var distrTimeEls = item.QuerySelectorAll(".distr-time");
                        var distrPriceEls = item.QuerySelectorAll(".distr-price");

                        Agent agent = new Agent()
                        {
                            UserId = item.GetAttribute("data-id"),
                            HeadImg = item.QuerySelector(".distr-img").QuerySelector("img").GetAttribute("src"),
                            Name = item.QuerySelector(".distr-name").QuerySelector("input").GetAttribute("data-name"),
                            Mobile = item.QuerySelector(".distr-mobile").InnerHtml,
                            TotalAmount = distrPriceEls[0].TextContent,
                            CurrentMothlAmount = distrPriceEls[1].TextContent,
                            FirstAgentTime = distrTimeEls[0].InnerHtml.Replace("<br>", ""),
                            LastUpDateTime = distrTimeEls[1].InnerHtml.Replace("<br>", ""),
                            ShopId = item.GetAttribute("data-shop"),
                        };
                        var itemUrl = $"{baseUrl}{item.QuerySelector(".opts").QuerySelector("a").GetAttribute("href")}";
                        var itemResult = await httpClient.GetStringAsync(itemUrl);
                        var itemHtml = await parser.ParseAsync(itemResult);

                        //用户等级
                        var agnetLevel = itemHtml.QuerySelector("#J_distrLvl").TextContent;
                        agent.Level = agnetLevel;

                        //用户所属团
                        var tuanEls = itemHtml.QuerySelector(".distr-stats").QuerySelectorAll("li")[1].QuerySelectorAll("span");
                        var tuanStr = new StringBuilder();
                        var tuanIdStr = new StringBuilder();
                        foreach (var tuan in tuanEls)
                        {
                            tuanStr.Append(tuan.TextContent).Append("|");

                            var tuanIdANode = tuan.QuerySelector("a");
                            if (tuanIdANode != null)
                            {
                                var tuanId = tuanIdANode.GetAttribute("data-team-id");
                                tuanIdStr.Append(tuanId).Append("|");
                            }
                        }

                        var tuanstrs = tuanStr.ToString().TrimEnd('|');
                        agent.BelongTuan = tuanstrs.Equals("暂未加入团队") ? "" : tuanstrs;

                        var tuanIdStrs = tuanIdStr.ToString().TrimEnd('|');
                        agent.TuanIds = tuanIdStrs;

                        agent.CreateTime = DateTime.Now;
                        agentList.Add(agent);
                    }

                    using (var context = new TswwDbContext())
                    {
                        foreach (var item in agentList)
                        {
                            var agent = context.Agents.SingleOrDefault(s => s.UserId == item.UserId);
                            if (agent != null)
                            {
                                agent.TotalAmount = item.TotalAmount;
                                agent.CurrentMothlAmount = item.CurrentMothlAmount;
                                agent.TuanIds = item.TuanIds;
                                agent.BelongTuan = item.BelongTuan;
                                agent.IsUpdated = true;
                                agent.UpdatedTime = DateTime.Now;
                            }
                            else
                            {
                                item.IsUpdated = true;
                                item.UpdatedTime = DateTime.Now;
                                context.Agents.Add(item);
                            }
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        #endregion

        #region 获取团
        /// <summary>
        /// 获取团
        /// </summary>
        /// <param name="loginUrl"></param>
        /// <param name="tuanUrl"></param>
        /// <returns></returns>
        public static async Task GetTuanList(string loginUrl, string tuanUrl)
        {
            CookieContainer cookiescontainer = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                CookieContainer = cookiescontainer,
                AllowAutoRedirect = true,
                UseCookies = true
            };
            var httpClient = new HttpClient(handler);
            var result = await httpClient.PostAsync(loginUrl, new FormUrlEncodedContent(Common.GetPostPara()));
            if (result.IsSuccessStatusCode)
            {
                var parser = new HtmlParser();
                var pageResult = await httpClient.GetStringAsync(tuanUrl);
                var document = await parser.ParseAsync(pageResult);
                var tbodys = document.QuerySelectorAll("tbody");
                var trElements = tbodys[0].QuerySelectorAll("tr");

                List<Tuan> tuanList = new List<Tuan>();

                foreach (var item in trElements)
                {
                    var teamTdNodes = item.QuerySelectorAll("td");
                    Tuan tuan = new Tuan
                    {
                        TuanId = item.GetAttribute("data-id"),
                        HeadImg = item.QuerySelector(".col-team").QuerySelector("img").GetAttribute("src"),
                        Name = item.QuerySelector(".cell").TextContent,
                        TuanType = teamTdNodes[2].QuerySelector(".cell").TextContent,
                        TuanRenShu = teamTdNodes[3].QuerySelector(".cell").TextContent,
                        TuanZhang = teamTdNodes[4].QuerySelector(".cell").TextContent,
                        FanLiType = teamTdNodes[5].QuerySelector(".cell").TextContent,
                        TotalAmount = teamTdNodes[6].QuerySelector(".cell").TextContent,
                        TotalSaleCount = teamTdNodes[7].QuerySelector(".cell").TextContent,
                        TuanCreateTime = teamTdNodes[8].QuerySelector(".cell").TextContent,
                        IsUpdate = true,
                        UpdateTime = DateTime.Now,
                        CreateTime = DateTime.Now
                    };
                    tuanList.Add(tuan);
                }

                using (var context = new TswwDbContext())
                {
                    foreach (var item in tuanList)
                    {
                        var tuan = context.Tuans.SingleOrDefault(s => s.TuanId == item.TuanId);
                        if (tuan != null)
                        {
                            tuan.Name = item.Name;
                            tuan.TuanRenShu = item.TuanRenShu;
                            tuan.TotalAmount = item.TotalAmount;
                            tuan.TotalSaleCount = item.TotalSaleCount;
                        }
                        else
                        {
                            context.Tuans.Add(item);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
        #endregion
    }
}