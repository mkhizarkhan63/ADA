using ADA.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.web.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    [Route("DashBoard")]
    public class LogoutModule : Controller
    {
        public string BaseUrl = "";
        public LogoutModule(IConfiguration configuration)
        {
            BaseUrl = configuration.GetSection("UrlSetting").GetSection("baseApiUrl").Value;
        }
        [Route("Logout")]
        [HttpPost]
        public Task<object> Logout()
        {
            string content = "";
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            //string a=HttpContext.Session.GetString("authorization");
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Authentication/Logout", content, HttpContext);

        }
    }
}
