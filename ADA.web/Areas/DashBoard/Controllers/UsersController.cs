using ADA.web.Models;
using ADAClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ADA.web.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    [Route("DashBoard")]
    public class UsersController : Controller
    {
        public string BaseUrl = "";
        public UsersController(IConfiguration configuration)
        {
            BaseUrl = configuration.GetSection("UrlSetting").GetSection("baseApiUrl").Value;
        }

        [Route("Users")]
        public IActionResult Users() {
            return View();
        }



        [Route("AddUsers")]
        [HttpPost]
        public Task<object> AddUsers([FromBody] Users obj)
        {
            string content = JsonConvert.SerializeObject(obj);
           
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Users/Add", content, HttpContext);
        }

        [Route("UpdateUsers")]
        [HttpPost]
        public Task<object> UpdateUsers([FromBody] Users obj)
        {
            string content = JsonConvert.SerializeObject(obj);
           
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Users/Update", content, HttpContext);
        }
        
        [Route("GetAllUsers")]
        [HttpPost]
        public Task<object> GetAllUsers()
        {
            string content = "";
            return HttpClientUtility.CustomHttpForGetAll(BaseUrl, "api/Users/GetAll", content, HttpContext);
        }
        [Route("GetUsersByID/{Id}")]
        [HttpPost]
        public Task<object> GetUsersByID(int Id)
        {
            string content = "";
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Users/GetUsersByID/" + Id, content, HttpContext);
        }

        [Route("ChangeStatus/{Id}")]
        [HttpPost]
        public Task<object> Delete(int id)
        {
            string content = "";
            //var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            //var byteContent = new ByteArrayContent(buffer);
            //string a=HttpContext.Session.GetString("authorization");
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Users/Delete/" + id, content, HttpContext);

        }   
        
        
        [Route("GetPageLoadData")]
        [HttpPost]
        public Task<object> GetPageLoadData()
        {
            string content = "";
      
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Users/GetPageLoadData", content, HttpContext);

        }

    }

}

