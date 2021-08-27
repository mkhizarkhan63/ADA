using ADA.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ADA.web.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    [Route("DashBoard/[controller]/[action]")]
    public class FlightController : Controller
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

       
        public IActionResult Flight() {
            return View();
        }



        [HttpPost]
        public Task<object> GetAllFlights()
        {
            string content = "";
            
            //JsonConvert.SerializeObject(obj);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            //var byteContent = new ByteArrayContent(buffer);
            //string a=HttpContext.Session.GetString("authorization");


            return HttpClientUtility.CustomHttpForGetAll("localhost:44317/", "api/Flight/GetAll", content, HttpContext);
        }

    }

}

