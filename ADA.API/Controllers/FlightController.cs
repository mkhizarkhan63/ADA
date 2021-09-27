using ADA.API.Utility;
using ADAClassLibrary;
using ADAClassLibrary.DTOLibraries;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Threading;
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

        //private readonly string cacheNameAircrafts = "Aircraft";
        //private readonly string cacheNameDestinations = "Destinatiion";
        //private readonly string cacheNamePilots = "Pilot";
        //private readonly string cacheNameStaff = "Staff";
        //private readonly string cacheNameFlightStatus = "FlightStatus";

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
        public Response Add([FromBody] Flight obj)
        {
            ClaimDTO claimDTO = null;
            Response response = new Response();

            try
            {
                claimDTO = TokenManager.GetValidateToken(Request);
                if (claimDTO == null) return CustomStatusResponse.GetResponse(401);
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
                var res = services.flightService.Add(obj);
                response = CustomStatusResponse.GetResponse(200);
                response.Token = TokenManager.GenerateToken(claimDTO);
                if (res != null)
                {

                    #region Set New Entry In Cache
                    //obj.Id = res;
                    res.FltTSEdit = DateTime.Now;
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
                response.Token = TokenManager.GenerateToken(claimDTO);
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
                response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = ex.Message;
                return response;
            }

        }

        [HttpPost("Update")]
        public Response Update(Flight obj)
        {

            ClaimDTO claimDTO = null;
            Response response = new Response();
            try
            {
                claimDTO = TokenManager.GetValidateToken(Request);
                if (claimDTO == null) return CustomStatusResponse.GetResponse(401);

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
                var res = services.flightService.Update(obj);
                response = CustomStatusResponse.GetResponse(200);
                response.Token = TokenManager.GenerateToken(claimDTO);
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
                response.Token = TokenManager.GenerateToken(claimDTO);
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
                response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = "Internal server error!";
                return response;
            }

        }

        [HttpPost("GetAllDropdowns")]
        public Response GetAllDropDowns()
        {   
            
            ClaimDTO claimDTO = null;
            Response response = new Response();
            claimDTO = TokenManager.GetValidateToken(Request);
            if (claimDTO == null) return CustomStatusResponse.GetResponse(401);
            try
            {
               
                var res = services.flightService.GetDropdownValues();
                response = CustomStatusResponse.GetResponse(200);
  
                if (res != null)
                {
                    response.Data = res;
                    response.Token = TokenManager.GenerateToken(claimDTO);
                }
                return response;



            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(600);
                response.Token = TokenManager.GenerateToken(claimDTO);
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
                response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = ex.Message;
                return response;
            }
        }


       [HttpPost("GetAircraftType")]
        public Response GetAircraftType(string value)
        {   
            
            ClaimDTO claimDTO = null;
            Response response = new Response();
            claimDTO = TokenManager.GetValidateToken(Request);
            if (claimDTO == null) return CustomStatusResponse.GetResponse(401);
            try
            {

                var res = services.flightService.GetAircraftType(value);

                

                response = CustomStatusResponse.GetResponse(200);
  
                if (res != null)
                {
                    response.Data = res;
                   response.Token = TokenManager.GenerateToken(claimDTO);
                }
                return response;



            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(600);
                response.Token = TokenManager.GenerateToken(claimDTO);
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
                response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = ex.Message;
                return response;
            }
        }
      

        [HttpPost("GetAll")]
        public Pagination GetAll()
        {
            ClaimDTO claimDTO = null;
            try
            {
                claimDTO = TokenManager.GetValidateToken(Request);

                if (claimDTO == null)
                {
                    Pagination response = new Pagination()
                    {
                        draw = "",
                        recordsFiltered = 0,
                        recordsTotal = 0,
                        Status = 401,
                        ResponseMsg = "unauthorized",
                        Token = null,
                        Data = null
                    };

                    return response;
                }
                // var Permissions = JsonConvert.DeserializeObject<List<string>>(claimDTO.Permissions);
                //string Controller = ControllerContext.ActionDescriptor.ControllerName;
                //bool HasPermission = true;
                //if (!claimDTO.DesignationId.Contains(1))
                //{
                //    HasPermission = false;
                //    if (Permissions != null && Permissions.Count > 0 && Permissions.Contains(PermissionEnum.ViewBranch.ToString()))
                //    {
                //        HasPermission = true;
                //    }
                //}
                // //if (!HasPermission)
                // //{
                // //    Pagination response = new Pagination()
                //     {
                //         draw = "",
                //         recordsFiltered = 0,
                //         recordsTotal = 0,
                //         Status = 403,
                //         ResponseMsg = "You don’t have permission to this action.",
                //       // Token = TokenManager.GenerateToken(claimDTO),
                //         Data = null
                //     };
                //     return response;
                //// }
                //HttpRequestMessage 
                //HttpRequestMessage m = new HttpRequestMessage();
                //var draw1 = HttpContext.Request.Form.Keys;

                var draw = HttpContext.Request.Headers["draw"].FirstOrDefault();
                var start = HttpContext.Request.Headers["start"].FirstOrDefault();
                var length = HttpContext.Request.Headers["length"].FirstOrDefault();
                var sortColumn = HttpContext.Request.Headers["sortColumn"].FirstOrDefault();
                var sortColumnDir = HttpContext.Request.Headers["sortColumnDir"].FirstOrDefault();
                var searchValue = HttpContext.Request.Headers["searchValue"].FirstOrDefault();
                //var start = HttpContext.Request.Form["sortColumnDir"].FirstOrDefault();
                //var length = HttpContext.Request.Form["length"].FirstOrDefault();
                //var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                //var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                //var searchValue = Request.Form["search[value]"].FirstOrDefault();
                var FromDate = HttpContext.Request.Headers["FromDate"].FirstOrDefault();
                var ToDate = HttpContext.Request.Headers["ToDate"].FirstOrDefault();
                var AirCraftType = HttpContext.Request.Headers["AirCraftType"].FirstOrDefault();

                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;


                var Data = cacheManager.TryGetValue(cacheName).ToList();


                if (AirCraftType!="")
                {
                    Data = Data.Where(x => (x.ACType==null?false:x.ACType.Contains(AirCraftType))).ToList();
                }
                if (FromDate!="")
                {
                    if (ToDate!="")
                    {
                        DateTime startDate = DateTime.Parse(FromDate);
                        DateTime endDate = DateTime.Parse(ToDate);


                        Data = Data.Where(t => DateTime.Parse(t.ETD) >= startDate && DateTime.Parse(t.ETD) <= endDate || DateTime.Parse(t.ETD) <= startDate && DateTime.Parse(t.ETD) >= endDate).ToList();

                    }
                }


                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {


                    string str = sortColumn;


                    sortColumn=sortColumn = char.ToUpper(str[0]) + str.Substring(1);

                 

                    if (sortColumnDir == "asc")
                    {

                        
                    Data = Data.OrderBy(item => typeof(Flight).GetProperty(sortColumn)?.GetValue(item)).ToList();
                    }
                    else
                    {
                     Data = Data.OrderByDescending(item => typeof(Flight).GetProperty(sortColumn)?.GetValue(item)).ToList();
                    }
                }


                
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    searchValue = searchValue.ToString().ToLower();

                    Data = Data.Where(m => m.FltID.ToString().Contains(searchValue)


                     || (m.ETD == null ? false : (DateTime.Parse(m.ETD).ToString("MM/dd/yyy hh:mm tt")).ToLower().Contains(searchValue))
                     || (m.FltTimeStamp == null ? false : (m.FltTimeStamp.Value.ToString("MM/dd/yyy hh:mm tt")).ToLower().Contains(searchValue))
                    || (m.Destination == null ? false : m.Destination.ToString().ToLower().Contains(searchValue))
                    || (m.FltNumber == null ? false : m.FltNumber.ToString().ToLower().Contains(searchValue))
                    || (m.Destination2 == null ? false : m.Destination2.ToString().ToLower().Contains(searchValue))
                  
                    || (m.Status == null ? false :m.Status.ToString().ToLower().Contains(searchValue))
                    || (m.Aircraft == null ? false : m.Aircraft.ToString().ToLower().Contains(searchValue))
                   || (m.Color == null ? false : m.Color.ToString().ToLower().Contains(searchValue))
                   || (m.Pilot1 == null? false : m.Pilot1.ToString().ToLower().Contains(searchValue))
                   || (m.Pilot2 == null ? false : m.Pilot2.ToString().ToLower().Contains(searchValue))
                   || (m.Pilot3 == null ? false : m.Pilot3.ToString().ToLower().Contains(searchValue))
                   || (m.FA1 == null ? false : m.FA1.ToString().ToLower().Contains(searchValue))
                   || (m.FA2 == null? false : m.FA2.ToString().ToLower().Contains(searchValue))
                   || (m.FA3 == null ? false : m.FA3.ToString().ToLower().Contains(searchValue))
                   || (m.FA4 == null? false : m.FA4.ToString().ToLower().Contains(searchValue))
                   || (m.Agent == null ? false : m.Agent.ToString().ToLower().Contains(searchValue))
                   || (m.FltRemarks == null ? false : m.FltRemarks.ToString().ToLower().Contains(searchValue))
                   || (m.SubManifestColor == null ? false : m.SubManifestColor.ToString().ToLower().Contains(searchValue))
                   || (m.CustCode == null ? false : m.CustCode.ToString().ToLower().Contains(searchValue))
                   || (m.FltRoute == null ? false : m.FltRoute.ToString().ToLower().Contains(searchValue))
                   || (m.Payload.ToString().ToLower().Contains(searchValue))
                   || (m.Fuel.ToString().Contains(searchValue))
                   || (m.Temperature.ToString().ToLower().Contains(searchValue))
                   || (m.GateNum.ToString().ToLower().Contains(searchValue))
                   || (m.RsrvdSeats.ToString().ToLower().Contains(searchValue))
                   //|| (m.UsePaxList.ToString().ToLower().Contains(searchValue == "1" ? "true" : "false"))
                   //|| (m.SeatMap.ToString().ToLower().Contains(searchValue == "1" ? "true" : "false"))
                   //|| (m.SplitGender.ToString().ToLower().Contains(searchValue == "1" ? "true" : "false"))
                   //|| (m.ShowRCS.ToString().ToLower().Contains(searchValue == "1" ? "true" : "false"))
                   || (m.FwdCargo1.ToString().ToLower().Contains(searchValue))
                   || (m.FwdCargo2.ToString().ToLower().Contains(searchValue))
                   || (m.FwdCargo3.ToString().ToLower().Contains(searchValue))
                   || (m.FwdCargo4.ToString().ToLower().Contains(searchValue))
                   || (m.AftCargo1.ToString().ToLower().Contains(searchValue))
                   || (m.AftCargo2.ToString().ToLower().Contains(searchValue))
                   || (m.AftCargo3.ToString().ToLower().Contains(searchValue))
                   || (m.AftCargo4.ToString().ToLower().Contains(searchValue))
                   || (m.AftCargo5.ToString().ToLower().Contains(searchValue))
                   || (m.AftCargo6.ToString().ToLower().Contains(searchValue))
                   || (m.ActualDepTime.ToString().ToLower().Contains(searchValue))


                   )?.ToList();
                }

                 recordsTotal = Data.Count();

                if (sortColumn == "Etd" && sortColumnDir == "desc")
                {
                    Data = Data.OrderByDescending(d => d.FltTSEdit).ToList();

                    Data = Data.Skip(skip).ToList();
                    Data = Data.Take(pageSize).ToList();


                }
                else
                {
                    Data = Data.Skip(skip).Take(pageSize).ToList();
                }
                Pagination pagination = new Pagination()
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    Status = 200,
                    Token = TokenManager.GenerateToken(claimDTO),
                    Data = Data
                };
                return pagination;
            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                Pagination pagination = new Pagination()
                {

                    //ResponseMsg = IsDBExceptionEnabeled ? "An Error Occured" : ex.Message,
                    Status = 600,
                    Token = TokenManager.GenerateToken(claimDTO),
                    Data = null,
                };
                return pagination;
            }
            catch (Exception ex)
            {
            //    WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
            //    _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                Pagination pagination = new Pagination()
                {
                    ResponseMsg = "Internal server error!",
                    Status = 500,
                    Token = TokenManager.GenerateToken(claimDTO),
                    Data = null,
                };
                return pagination;
            }

        }


        [HttpPost("GetFlightBtID/{Id}")]
        public Response GetFlightBtID(int Id)
        {

            ClaimDTO claimDTO = null;
            Response response = new Response();

            try
            {
                claimDTO = TokenManager.GetValidateToken(Request);
                if (claimDTO == null) return CustomStatusResponse.GetResponse(401);



                var res = cacheManager.TryGetValue(cacheName).ToList().FirstOrDefault(x => x.FltID == Id);

                response = CustomStatusResponse.GetResponse(200);
                response.Token = TokenManager.GenerateToken(claimDTO);
                if (res != null)
                {
                   

                    response.Data = res;


                }
               
                return response;



            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetBranchById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetBranchById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(600);
                response.Token = TokenManager.GenerateToken(claimDTO);
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
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetBranchById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetBranchById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(500);
                response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = "Internal server error!";
                return response;
            }

        }

    }





}


    


