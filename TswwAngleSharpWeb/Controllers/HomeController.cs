using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using AngleSharp.Parser.Html;
using TswwAngleSharpWeb.BLL;
using TswwAngleSharpWeb.Models;

namespace TswwAngleSharpWeb.Controllers
{
    public class HomeController : Controller
    {
        public static CookieContainer CookieContainer = new CookieContainer();
        //base Url
        private const string BaseUrl = "http://sp.wdwd.com";
        //登录地址
        private const string LoginUrl = BaseUrl + "/passport/verify";
        private const string TuanUrl = BaseUrl + "/teams";

        private const int StartPage = 1;
        private const int MaxPage = 199;
        public async Task<ActionResult> Index()
        {
           // await GetWebDataBLL.GetAgentList(StartPage, MaxPage, LoginUrl, BaseUrl);
            await GetWebDataBLL.GetTuanList(LoginUrl, TuanUrl);
            return View();
        }

        public async Task<ActionResult> LookUp()
        {
            var list = await LookUpDiffBLL.GetDiffAgent();
            return View(list);
        }

    }
}