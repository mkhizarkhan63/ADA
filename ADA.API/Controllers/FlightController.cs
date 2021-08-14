using ADA.API.Utility;
using ADAClassLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDIUnit _service;
        private readonly IConfiguration _confgiuration;
        private readonly CacheManager<Flight> cacheManager;
        private readonly string cacheName = "Flight";
        public FlightController(IWebHostEnvironment env, IDIUnit unit, IConfiguration confgiuration)
        {
            _env = env;
            _service = unit;
            _confgiuration = confgiuration;
            cacheManager = new CacheManager<Flight>(unit.memoryCache, unit.flightService);
        }

        [HttpPost("AddFlight")]
        public Response Add(Flight obj)
        {

            Response response = new Response();

            try
            {
                var cacheData = cacheManager.TryGetValue(cacheName).ToList();
                var res = _service.flightService.Add(obj);
                response = CustomStatusResponse.GetResponse(200);
                if (res != null)
                {
                    cacheData.Add(res);
                    cacheManager.Remove(cacheName);
                    cacheManager.CreateEntry(cacheName, cacheData);
                    response.Data = res;
                    response.ResponseMsg = "Data save successfully!";
                }
                return response;
            }
            catch (Exception e)
            {
                response = CustomStatusResponse.GetResponse(600);
                response.ResponseMsg = e.Message;
                return response;
            }


        }

        [HttpPost("UpdateFlight")]
        public Response Update(Flight obj)
        {
            Response response = new Response();
            try
            {
                var res = _service.flightService.Update(obj);
                response = CustomStatusResponse.GetResponse(200);
                if (res != null)
                {
                    var cacheData = cacheManager.TryGetValue(cacheName).ToList();
                    var oldObj = cacheData.FirstOrDefault(x => x.FltID == res.FltID);
                    cacheData.Remove(oldObj);
                    cacheData.Add(res);
                    cacheManager.CreateEntry(cacheName, cacheData);
                    response.Data = res;
                    response.ResponseMsg = "Updated successfully!";
                }
                return response;
            }
            catch (DbException ex)
            {
                response = CustomStatusResponse.GetResponse(600);
                response.ResponseMsg = ex.Message;
                return response;

            }
            catch (Exception)
            {

                response = CustomStatusResponse.GetResponse(500);
                response.ResponseMsg = "Internal server error!";
                return response;

            }

        }

        [HttpPost("GetAllFlights")]
        public Response GetAll()
        {
            Response response = new Response();
            try
            {
                var res = cacheManager.TryGetValue(cacheName).ToList();

                response = CustomStatusResponse.GetResponse(200);

                response.Data = res;

                return response;



            }
            catch (DbException e)
            {
                response = CustomStatusResponse.GetResponse(600);
                response.ResponseMsg = e.Message;
                return response;
            }
            catch (Exception)
            {

                response = CustomStatusResponse.GetResponse(500);
                response.ResponseMsg = "Internal Server Error!";
                return response;
            }
        }


        [HttpPost("GetFlightByID")]
        public Response flightGetByID(int id)
        {
            Response response = new Response();

            try
            {
                var res = cacheManager.TryGetValue(cacheName).ToList().FirstOrDefault(x => x.FltID == id);
                response = CustomStatusResponse.GetResponse(200);
                response.Data = res;
                return response;

            }
            catch (DbException e)
            {

            
                response.ResponseMsg = e.Message;
                return response;
            }
            catch (Exception)
            {
                response = CustomStatusResponse.GetResponse(500);
                response.ResponseMsg = "Internal Server Error!";
                return response;
            }

        }
    }
}
