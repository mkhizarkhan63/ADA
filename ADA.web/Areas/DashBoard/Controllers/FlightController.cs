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
    public class FlightController : Controller
    {
        public string BaseUrl = "";
        public FlightController(IConfiguration configuration)
        {
            BaseUrl = configuration.GetSection("UrlSetting").GetSection("baseApiUrl").Value;
        }

        [Route("Flight")]
        public IActionResult Flight() {
            return View();
        }



        [Route("AddFlight")]
        [HttpPost]
        public Task<object> AddFlight([FromBody] Flight obj)
        {
            obj.FltTimeStamp = DateTime.Now;
            obj.ClosingAgentID = 1;

            string content = JsonConvert.SerializeObject(obj);
           
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Flight/Add", content, HttpContext);
        }

        [Route("UpdateFlight")]
        [HttpPost]
        public Task<object> UpdateFlight([FromBody] Flight obj)
        {

            obj.FltTSEdit = DateTime.Now;
            obj.ClosingAgentID = 1;


            string content = JsonConvert.SerializeObject(obj);
           
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Flight/Update", content, HttpContext);
        }
        
        [Route("GetAllDropdown")]
        [HttpPost]
        public Task<object> GetAllDropdown()
        {
            string content = ""; 
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Flight/GetAllDropdowns", content, HttpContext);
        }

        [Route("GetAllFlights")]
        [HttpPost]
        public Task<object> GetAllFlights()
        {
            string content = "";
            return HttpClientUtility.CustomHttpForFlightGetAllWithCustomParameters(BaseUrl, "api/Flight/GetAll", content, HttpContext);
        }
        [Route("GetFLightByID/{Id}")]
        [HttpPost]
        public Task<object> GetFLightByID(int Id)
        {
            string content = "";
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Flight/GetFlightBtID/" + Id, content, HttpContext);
        }

        [Route("GetAircraftType")]
        [HttpPost]
        public Task<object> GetAircraftType(string value)
        {
            string content = "";
            return HttpClientUtility.CustomHttp(BaseUrl, "api/Flight/GetAircraftType?value="+value, content, HttpContext);
        }

    }

}

