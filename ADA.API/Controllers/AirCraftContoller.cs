using ADA.API.IServices;
using ADAClassLibrary;

using ADA.API.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
    public class AirCraft : ControllerBase
    {

        private readonly IDIUnit _service; 

        //public double ExpireTime;
        //private readonly string _controllerName = "AirCraftController";
        //private readonly ILoggerService _loggerService;
        private readonly IConfiguration _configuration;


        private readonly CacheManager<Aircraft> cacheManager;
        private readonly string cacheName = "AirCraft";

        //private readonly string authenticationCacheName = "Authentication";
        //private readonly double UTCHours = 5.0;
        private readonly IWebHostEnvironment _env;
        public AirCraft(IWebHostEnvironment env, IDIUnit unit, IConfiguration confgiuration)
        {
            _configuration = confgiuration;
            _service = unit;
            cacheManager = new CacheManager<Aircraft>(unit.memoryCache, unit.airCraftService);
            // _loggerService = loggerService;
            _env = env;



        }


        [HttpPost("AddAircraft")]
        public Response Add(Aircraft obj)
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
                var res = _service.airCraftService.Add(obj);
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
                response.ResponseMsg = "Internal server error!";
                return response;
            }

        }


        [HttpPost("Update")]
        public Response Update(Aircraft obj)
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
                var res = _service.airCraftService.Update(obj);
                response = CustomStatusResponse.GetResponse(200);
                // response.Token = TokenManager.GenerateToken(claimDTO);
                if (res != null)
                {
                    #region Set New Entry In Cache

                    var cacheData = cacheManager.TryGetValue(cacheName).ToList();
                    var oldObj = cacheData.FirstOrDefault(x => x.AircraftID == res.AircraftID);


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


        [HttpPost("GetAllActive")]
        public Response GetAllActive()
        {

            //ClaimDTO claimDTO = null;
            Response response = new Response();

            try
            {
                //claimDTO = TokenManager.GetValidateToken(Request);
                //if (claimDTO == null) return CustomStatusResponse.GetResponse(401);


                //List<Company> res;
                //if (!claimDTO.DesignationId.Contains(1))
                //{
                //    res = cacheManager.TryGetValue(cacheName).ToList().Where(x => x.Active == true && claimDTO.Companies.Any(c => c == x.Id)).ToList();
                //}
                //else
                //{
                var res = cacheManager.TryGetValue(cacheName).ToList();
                // }

                response = CustomStatusResponse.GetResponse(200);
                //  response.Token = TokenManager.GenerateToken(claimDTO);

                response.Data = res;

                return response;



            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

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
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(500);
                //response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = "Internal server error!";
                return response;
            }

        }



        [HttpPost("AirCraftGetByID/{id}")]
        public Response AirCraftGetByID(int id)
        {

            //ClaimDTO claimDTO = null;
            Response response = new Response();

            try
            {
                //claimDTO = TokenManager.GetValidateToken(Request);
                //if (claimDTO == null) return CustomStatusResponse.GetResponse(401);


                //List<Company> res;
                //if (!claimDTO.DesignationId.Contains(1))
                //{
                //    res = cacheManager.TryGetValue(cacheName).ToList().Where(x => x.Active == true && claimDTO.Companies.Any(c => c == x.Id)).ToList();
                //}
                //else
                //{
                var res = cacheManager.TryGetValue(cacheName).ToList().Where(x => x.AircraftID == id);
                // }

                response = CustomStatusResponse.GetResponse(200);
                //  response.Token = TokenManager.GenerateToken(claimDTO);

                response.Data = res;

                return response;



            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

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
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAllActive", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(500);
                //response.Token = TokenManager.GenerateToken(claimDTO);
                response.ResponseMsg = "Internal server error!";
                return response;
            }

        }

        //[HttpPost("Delete/{id}")]
        //public Response Delete(int id)
        //{

        //    ClaimDTO claimDTO = null;
        //    Response response = new Response();

        //    try
        //    {
        //        claimDTO = TokenManager.GetValidateToken(Request);
        //        if (claimDTO == null) return CustomStatusResponse.GetResponse(401);
        //        var Permissions = JsonConvert.DeserializeObject<List<string>>(claimDTO.Permissions);
        //        // string Controller = ControllerContext.ActionDescriptor.ControllerName;
        //        bool HasPermission = true;
        //        if (!claimDTO.DesignationId.Contains(1))
        //        {
        //            HasPermission = false;
        //            if (Permissions != null && Permissions.Count > 0 && Permissions.Contains(PermissionEnum.ChangeStatusCompany.ToString()))
        //            {
        //                HasPermission = true;
        //            }
        //        }
        //        if (!HasPermission)
        //        {
        //            response = CustomStatusResponse.GetResponse(403);
        //            response.Token = TokenManager.GenerateToken(claimDTO);
        //            return response;
        //        }
        //        var modifiedOn = DateTime.UtcNow.AddHours(UTCHours);
        //        int res = _service.Delete(id, claimDTO.UserId, modifiedOn);
        //        response = CustomStatusResponse.GetResponse(200);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        if (res > 0)
        //        {

        //            #region Set New Entry In Cache
        //            var cacheData = cacheManager.TryGetValue(cacheName).ToList();
        //            var oldObj = cacheData.FirstOrDefault(x => x.Id == id);
        //            var newObj = cacheData.FirstOrDefault(x => x.Id == id);

        //            newObj.Active = !oldObj.Active;
        //            newObj.ModifiedOn = modifiedOn;
        //            newObj.CreatedBy = 0;
        //            cacheData.Remove(oldObj);
        //            cacheData.Add(newObj);
        //            cacheManager.Remove(cacheName);
        //            cacheManager.CreateEntry(cacheName, cacheData);
        //            #endregion
        //            response.Data = res;
        //            response.ResponseMsg = "Deleted successfully!";
        //        }
        //        return response;




        //    }
        //    catch (DbException ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        response = CustomStatusResponse.GetResponse(600);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        if (IsDBExceptionEnabeled)
        //        {
        //            response.ResponseMsg = "An Error Occured";
        //        }
        //        else
        //        {

        //            response.ResponseMsg = ex.Message;
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        response = CustomStatusResponse.GetResponse(500);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        response.ResponseMsg = "Internal server error!";
        //        return response;
        //    }

        //}


        //[HttpPost("DeleteCompanyRecord/{id}")]
        //public Response DeleteCompanyRecord(int id)
        //{

        //    ClaimDTO claimDTO = null;
        //    Response response = new Response();

        //    try
        //    {
        //        claimDTO = TokenManager.GetValidateToken(Request);
        //        if (claimDTO == null) return CustomStatusResponse.GetResponse(401);

        //        var Permissions = JsonConvert.DeserializeObject<List<string>>(claimDTO.Permissions);
        //        //string Controller = ControllerContext.ActionDescriptor.ControllerName;
        //        bool HasPermission = true;
        //        if (!claimDTO.DesignationId.Contains(1))
        //        {
        //            HasPermission = false;
        //            if (Permissions != null && Permissions.Count > 0 && Permissions.Contains(PermissionEnum.DeleteCompany.ToString()))
        //            {

        //                HasPermission = true;
        //            }
        //        }
        //        if (!HasPermission)
        //        {
        //            response = CustomStatusResponse.GetResponse(403);
        //            response.Token = TokenManager.GenerateToken(claimDTO);
        //            return response;
        //        }
        //        var modifiedOn = DateTime.UtcNow.AddHours(UTCHours);
        //        int res = _service.DeleteRecord(id);
        //        response = CustomStatusResponse.GetResponse(200);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        if (res > 0)
        //        {

        //            #region Set New Entry In Cache
        //            var cacheData = cacheManager.TryGetValue(cacheName).ToList();
        //            var oldObj = cacheData.FirstOrDefault(x => x.Id == id);
        //            cacheData.Remove(oldObj);
        //            cacheManager.Remove(cacheName);
        //            cacheManager.CreateEntry(cacheName, cacheData);
        //            #endregion
        //            response.Data = res;
        //            response.ResponseMsg = "Deleted Record successfully!";
        //        }
        //        return response;




        //    }
        //    catch (DbException ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        response = CustomStatusResponse.GetResponse(600);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        if (IsDBExceptionEnabeled)
        //        {
        //            response.ResponseMsg = "An Error Occured";
        //        }
        //        else
        //        {

        //            response.ResponseMsg = ex.Message;
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Delete", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        response = CustomStatusResponse.GetResponse(500);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        response.ResponseMsg = "Internal server error!";
        //        return response;
        //    }

        //}

        //[HttpPost("GetCompanyById/{id}")]
        //public Response GetCompanyById(int id)
        //{

        //    ClaimDTO claimDTO = null;
        //    Response response = new Response();

        //    try
        //    {
        //        claimDTO = TokenManager.GetValidateToken(Request);
        //        if (claimDTO == null) return CustomStatusResponse.GetResponse(401);



        //        var res = cacheManager.TryGetValue(cacheName).ToList().FirstOrDefault(x => x.Id == id);

        //        //var res = _service.GetCompanyById(id);

        //        response = CustomStatusResponse.GetResponse(200);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        if (res != null)
        //        {
        //            response.Data = res;
        //        }
        //        return response;



        //    }
        //    catch (DbException ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetCompanyById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetCompanyById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        response = CustomStatusResponse.GetResponse(600);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        if (IsDBExceptionEnabeled)
        //        {
        //            response.ResponseMsg = "An Error Occured";
        //        }
        //        else
        //        {

        //            response.ResponseMsg = ex.Message;
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetCompanyById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetCompanyById", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        response = CustomStatusResponse.GetResponse(500);
        //        response.Token = TokenManager.GenerateToken(claimDTO);
        //        response.ResponseMsg = "Internal server error!";
        //        return response;
        //    }

        //}



        //[HttpPost("GetAll")]
        //public Pagination GetAll()
        //{
        //    ClaimDTO claimDTO = null;
        //    try
        //    {
        //        claimDTO = TokenManager.GetValidateToken(Request);

        //        if (claimDTO == null)
        //        {
        //            Pagination response = new Pagination()
        //            {
        //                draw = "",
        //                recordsFiltered = 0,
        //                recordsTotal = 0,
        //                Status = 401,
        //                ResponseMsg = "unauthorized",
        //                Token = null,
        //                Data = null
        //            };
        //            return response;
        //        }

        //        var Permissions = JsonConvert.DeserializeObject<List<string>>(claimDTO.Permissions);
        //        // string Controller = ControllerContext.ActionDescriptor.ControllerName;
        //        bool HasPermission = true;
        //        if (!claimDTO.DesignationId.Contains(1))
        //        {

        //            HasPermission = false;
        //            if (Permissions != null && Permissions.Count > 0 && Permissions.Contains(PermissionEnum.ViewCompany.ToString()))
        //            {
        //                HasPermission = true;
        //            }
        //        }
        //        if (!HasPermission)
        //        {
        //            Pagination response = new Pagination()
        //            {
        //                draw = "",
        //                recordsFiltered = 0,
        //                recordsTotal = 0,
        //                Status = 403,
        //                ResponseMsg = "You don’t have permission to this action.",
        //                Token = TokenManager.GenerateToken(claimDTO),
        //                Data = null
        //            };
        //            return response;
        //        }

        //        //HttpRequestMessage 
        //        //HttpRequestMessage m = new HttpRequestMessage();
        //        //var draw1 = HttpContext.Request.Form.Keys;

        //        var draw = HttpContext.Request.Headers["draw"].FirstOrDefault();
        //        var start = HttpContext.Request.Headers["start"].FirstOrDefault();
        //        var length = HttpContext.Request.Headers["length"].FirstOrDefault();
        //        var sortColumn = HttpContext.Request.Headers["sortColumn"].FirstOrDefault();
        //        var sortColumnDir = HttpContext.Request.Headers["sortColumnDir"].FirstOrDefault();
        //        var searchValue = HttpContext.Request.Headers["searchValue"].FirstOrDefault();
        //        //var start = HttpContext.Request.Form["sortColumnDir"].FirstOrDefault();
        //        //var length = HttpContext.Request.Form["length"].FirstOrDefault();
        //        //var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //        //var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
        //        //var searchValue = Request.Form["search[value]"].FirstOrDefault();


        //        //Paging Size (10,20,50,100)    
        //        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //        int skip = start != null ? Convert.ToInt32(start) : 0;
        //        int recordsTotal = 0;


        //        var Data = cacheManager.TryGetValue(cacheName).ToList();
        //        if (!claimDTO.DesignationId.Contains(1))
        //        {
        //            Data = Data.Where(x => claimDTO.Companies.Contains(x.Id.Value)).ToList();
        //        }

        //        //Sorting  
        //        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
        //        {
        //            if (sortColumnDir == "asc")
        //            {
        //                if (sortColumn == "Id")
        //                {
        //                    Data = Data.OrderBy(item => item.Id).ToList();
        //                }

        //                else
        //                {

        //                    Data = Data.OrderBy(item => typeof(Company).GetProperty(sortColumn).GetValue(item).ToString()).ToList();
        //                }
        //            }
        //            else
        //            {
        //                if (sortColumn == "Id")
        //                {
        //                    Data = Data.OrderByDescending(item => item.Id).ToList();
        //                }
        //                else
        //                {
        //                    Data = Data.OrderByDescending(item => typeof(Company).GetProperty(sortColumn).GetValue(item).ToString()).ToList();
        //                }
        //            }
        //        }
        //        //Search  
        //        if (!string.IsNullOrEmpty(searchValue))
        //        {
        //            var a = true;
        //            string b = a.ToString();
        //            searchValue = searchValue.ToLower();

        //            Data = Data.Where(m => m.Id.ToString().Contains(searchValue) || m.Name.ToLower().Contains(searchValue) || m.Code.ToLower().Contains(searchValue) || m.ModifiedOn.Value.ToString("dd/MM/yyyy hh:mm:ss tt").ToLower().Contains(searchValue) || (m.Active.ToString() != "True" ? "No" : "Yes").ToLower().Contains(searchValue)).ToList();

        //        }
        //        //total number of rows count     
        //        recordsTotal = Data.Count();
        //        //Paging  
        //        //List<Company> list = new List<Company>();
        //        if (sortColumn == "ModifiedOn" && sortColumnDir == "desc")
        //        {
        //            Data = Data.Skip(skip).OrderByDescending(d => d.ModifiedOn).Take(pageSize).ToList();
        //        }
        //        else
        //        {
        //            Data = Data.Skip(skip).Take(pageSize).ToList();
        //        }
        //        Pagination pagination = new Pagination()
        //        {
        //            draw = draw,
        //            recordsFiltered = recordsTotal,
        //            recordsTotal = recordsTotal,
        //            Status = 200,
        //            Token = TokenManager.GenerateToken(claimDTO),
        //            Data = Data
        //        };
        //        return pagination;
        //    }
        //    catch (DbException ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        Pagination pagination = new Pagination()
        //        {
        //            ResponseMsg = IsDBExceptionEnabeled ? "An Error Occured" : ex.Message,
        //            Status = 600,
        //            Token = TokenManager.GenerateToken(claimDTO),
        //            Data = null,
        //        };
        //        return pagination;
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
        //        _loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "GetAll", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

        //        Pagination pagination = new Pagination()
        //        {
        //            ResponseMsg = "Internal server error!",
        //            Status = 500,
        //            Token = TokenManager.GenerateToken(claimDTO),
        //            Data = null,
        //        };
        //        return pagination;
        //    }

        //}





    }

}
