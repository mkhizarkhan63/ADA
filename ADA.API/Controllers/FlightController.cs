﻿using ADA.API.Utility;
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
        private readonly IDIUnit services;

        //public double ExpireTime;
        //private readonly string _controllerName = "AirCraftController";
        //private readonly ILoggerService _loggerService;
        private readonly IConfiguration _configuration;


        private readonly CacheManager<Flight> cacheManager;
        private readonly string cacheName = "Flight";

        //private readonly string authenticationCacheName = "Authentication";
        //private readonly double UTCHours = 5.0;
        private readonly IWebHostEnvironment _env;
        public FlightController(IWebHostEnvironment env, IDIUnit unit, IConfiguration confgiuration)
        {
            _configuration = confgiuration;
            services = unit;
            cacheManager = new CacheManager<Flight>(unit.memoryCache, unit.flightService);
            // _loggerService = loggerService;
            _env = env;

        }

        [HttpPost("Add")]
        public Response Add(Flight obj)
        {
            // ClaimDTO claimDTO = null;
            Response response = new Response();

            try
            {
                //  claimDTO = TokenManager.GetValidateToken(Request);
                // if (claimDTO == null) return CustomStatusResponse.GetResponse(401);
                // var Permissions = JsonConvert.DeserializeObject<List<string>>(claimDTO.Permissions);
                //  bool HasPermission = true;
                // if (!claimDTO.DesignationId.Contains(1))
                // {
                //  HasPermission = false;
                //  if (Permissions != null && Permissions.Count > 0 && Permissions.Contains(PermissionEnum.AddCompany.ToString()))
                //    {

                //        HasPermission = true;
                //    }
                //}
                //if (!HasPermission)
                //{
                //    response = CustomStatusResponse.GetResponse(403);
                //    response.Token = TokenManager.GenerateToken(claimDTO);
                //    return response;
                //}
                var cacheData = cacheManager.TryGetValue(cacheName).ToList();
                //obj.ModifiedOn = DateTime.UtcNow.AddHours(UTCHours);
                //obj.CreatedBy = claimDTO.UserId;
                var res = services.flightService.AddFlight(obj);
                response = CustomStatusResponse.GetResponse(200);
                // response.Token = TokenManager.GenerateToken(claimDTO);
                if (res != null)
                {

                    #region Set New Entry In Cache
                    //obj.Id = res;

                    cacheData.Add(res);
                    cacheManager.Remove(cacheName);
                    cacheManager.CreateEntry(cacheName, cacheData);

                    #endregion

                    response.Data = res;
                    response.ResponseMsg = "Data save successfully!";
                }
                return response;



            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(600);
                //response.Token = TokenManager.GenerateToken(claimDTO);
                //if (IsDBExceptionEnabeled)
                //{
                //    response.ResponseMsg = "An Error Occured";
                //}
                //else
                //{

                response.ResponseMsg = ex.Message;
                // }

                return response;
            }
            catch (Exception ex)
            {
                //    WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //    _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(500);
                // response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = ex.Message;
                return response;
            }

        }

        [HttpPost("Update")]
        public Response Update(Flight obj)
        {

            //ClaimDTO claimDTO = null;
            Response response = new Response();
            try
            {
                //claimDTO = TokenManager.GetValidateToken(Request);
                //if (claimDTO == null) return CustomStatusResponse.GetResponse(401);

                //var Permissions = JsonConvert.DeserializeObject<List<string>>(claimDTO.Permissions);
                ////   string Controller = ControllerContext.ActionDescriptor.ControllerName;
                //bool HasPermission = true;
                //if (!claimDTO.DesignationId.Contains(1))
                //{
                //    HasPermission = false;
                //    if (Permissions != null && Permissions.Count > 0 && Permissions.Contains(PermissionEnum.EditCompany.ToString()))
                //    {
                //        HasPermission = true;
                //    }
                //}
                //if (!HasPermission)
                //{
                //    response = CustomStatusResponse.GetResponse(403);
                //    response.Token = TokenManager.GenerateToken(claimDTO);
                //    return response;
                //}
                ////Get Data Logic Here
                //obj.ModifiedOn = DateTime.UtcNow.AddHours(UTCHours);
                //obj.CreatedBy = claimDTO.UserId;
                var res = services.flightService.UpdateFlight(obj);
                response = CustomStatusResponse.GetResponse(200);
                // response.Token = TokenManager.GenerateToken(claimDTO);
                if (res != null)
                {
                    #region Set New Entry In Cache

                    var cacheData = cacheManager.TryGetValue(cacheName).ToList();
                    var oldObj = cacheData.FirstOrDefault(x => x.FltID == res.FltID);


                    cacheData.Remove(oldObj);
                    cacheData.Add(res);

                    cacheManager.Remove(cacheName);
                    cacheManager.CreateEntry(cacheName, cacheData);



                    #endregion
                    response.Data = res;
                    response.ResponseMsg = "Updated successfully!";
                }
                //Get Data Login End
                return response;

            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Update", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Update", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(600);
                //response.Token = TokenManager.GenerateToken(claimDTO);
                //if (IsDBExceptionEnabeled)
                //{
                //    response.ResponseMsg = "An Error Occured";
                //}
                //else
                //{

                response.ResponseMsg = ex.Message;
                //}

                return response;
            }
            catch (Exception ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Update", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Update", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(500);
                // response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = "Internal server error!";
                return response;
            }

        }



    }
}


    
