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
    public class RoleController : Controller
    {
        public string BaseUrl = "";
        public RoleController(IConfiguration configuration)
        {
            BaseUrl = configuration.GetSection("UrlSetting").GetSection("baseApiUrl").Value;
        }

        [Route("Role")]
        public IActionResult Role() {
            return View();
        }



        [Route("AddRole")]
        [HttpPost]
        public Task<object> AddRole([FromBody] Role obj)
        {
            string content = JsonConvert.SerializeObject(obj);
           
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Role/Add", content, HttpContext);
        }

        [Route("UpdateRole")]
        [HttpPost]
        public Task<object> UpdateRole([FromBody] Role obj)
        {
            string content = JsonConvert.SerializeObject(obj);
           
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Role/Update", content, HttpContext);
        }
        
        [Route("GetAllRoles")]
        [HttpPost]
        public Task<object> GetAllRoles()
        {
            string content = "";
            return HttpClientUtility.CustomHttpForGetAll(BaseUrl, "api/Role/GetAll", content, HttpContext);
        }
        [Route("GetRoleByID/{Id}")]
        [HttpPost]
        public Task<object> GetRoleByID(int Id)
        {
            string content = "";
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Role/GetRoleByID/" + Id, content, HttpContext);
        }

        [Route("Delete/{Id}")]
        [HttpPost]
        public Task<object> Delete(int id)
        {
            string content = "";
            //var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            //var byteContent = new ByteArrayContent(buffer);
            //string a=HttpContext.Session.GetString("authorization");
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Role/Delete/" + id, content, HttpContext);

        }

    }

}

