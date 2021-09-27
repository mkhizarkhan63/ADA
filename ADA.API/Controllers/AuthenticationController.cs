using ADA.API.Utility;
using ADA.IServices;
using ADAClassLibrary;
using ADAClassLibrary.DTOLibraries;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IAuthenticationService _authenticationService;
        //private readonly ILoggerService _loggerService;
        //private readonly IDesignationService _designationService;
        //private readonly ICompanyService _companyService;
        //private readonly IBranchService _branchService;
        //private readonly IFactoryService _factoryService;
        //private readonly IPermissionService _permissionService;
        //private readonly IEmployeeService _employeeService;
        //private readonly ITeamService _teamService;
        //private readonly IBMCEnvicreteModuleService _bMCEnvicreteModuleService;
        //private readonly IBMCEnvicreteModulePagesService _bMCEnvicreteModulePagesService;
        //private readonly IBMCEnvicreteModulePagesActionService _bMCEnvicreteModulePagesActionService;
        private readonly IWebHostEnvironment _env;
        private readonly string _controllerName = "AuthenticationController";
        //private readonly string permissionCacheName = "Permission";
        //private readonly string designationCacheName = "Designation";
        //private readonly string companyCacheName = "Company";
        //private readonly string branchCacheName = "Branch";
        //private readonly string factoryCacheName = "Factory";
        //private readonly string teamCacheName = "Team";
        //private readonly string employeeCacheName = "Employee";
        private readonly string bMCEnvicreteModuleCacheName = "BMCEnvicreteModule";
        private readonly string bMCEnvicreteModulePagesCacheName = "BMCEnvicreteModulePages";
        private readonly string bMCEnvicreteModulePagesActionCacheName = "BMCEnvicreteModulePagesAction";
        private readonly int IsEmailSend;
        private readonly double UTCHours = 5.0;
        public bool IsDBExceptionEnabeled = false;
        public AuthenticationController(IConfiguration confgiuration, IAuthenticationService authenticationService, IMemoryCache memoryCache, IWebHostEnvironment env)
        {
            //IsDBExceptionEnabeled = Convert.ToBoolean(confgiuration.GetSection("IsDBExceptionEnabeled").Value);

            _memoryCache = memoryCache;
            _authenticationService = authenticationService;
            //_loggerService = loggerService;
            //_permissionService = permissionService;
            //_designationService = designationService;
            //_companyService = companyService;
            //_factoryService = factoryService;
            //_branchService = branchService;
            //_teamService = teamService;
            //_employeeService = employeeService;
            //_bMCEnvicreteModuleService = bMCEnvicreteModuleService;
            //_bMCEnvicreteModulePagesService = bMCEnvicreteModulePagesService;
            //_bMCEnvicreteModulePagesActionService = bMCEnvicreteModulePagesActionService;
            _env = env;
        }
      

        [HttpPost("Authenticate")]
        public Response Authenticate(LoginCredentials obj)
        {
            Response response = new Response();
            ClaimDTO claimDTO = new ClaimDTO();
            try
            {

               // obj.Password = Secure.EncryptData(obj.Password);
                var user = _authenticationService.Authenticate(obj);
                if (user == null) return CustomStatusResponse.GetResponse(320);
                else
                {
                 
                    response = CustomStatusResponse.GetResponse(200);
                    response.Token = TokenManager.GenerateToken(user);
                    response.Data = new
                    {
                        DataObj = user,
                        //Menu = menu,
                        //IndexPageController = menu[0].DynamicModulePagesMenus[0].UrlController,
                        //IndexPageAction = menu[0].DynamicModulePagesMenus[0].UrlAction

                    };
                    return response;
                }
            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Authenticate", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Authenticate", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(600);
                if (IsDBExceptionEnabeled)
                {
                    response.ResponseMsg = "An Error Occured";
                }
                else
                {

                    response.ResponseMsg = ex.Message;
                }
                return response;
            }
            catch (Exception ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Authenticate", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Authenticate", claimDTO.Username, Convert.ToInt32(claimDTO.UserId), claimDTO.RoleId, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(500);
                response.ResponseMsg = "Internal server error!";
                return response;
            }
        }



        [HttpPost("Logout")]
        public Response Logout()
        {
            Response response;
            try
            {


                string token = Request.Headers["Authorization"];
                if (token != null)
                {
                    TokenManager.RemoveToken(token);
                }

                response = CustomStatusResponse.GetResponse(200);
                response.Data = null;
                response.Token = null;
                return response;

            }
            catch (DbException ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", "", 0, 0, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", "", 0, 0, 600, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(600);
                response.Token = null;
                if (IsDBExceptionEnabeled)
                {
                    response.ResponseMsg = "An Error Occured";
                }
                else
                {

                    response.ResponseMsg = ex.Message;
                }
                return response;
            }
            catch (Exception ex)
            {
                //WriteFileLogger.WriteLog(_env, Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", "", 0, 0, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                //_loggerService.CreateLog(Convert.ToString(Request.Path.HasValue == false ? "" : Request.Path.Value), _controllerName, "Add", "", 0, 0, 500, Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));

                response = CustomStatusResponse.GetResponse(500);
                response.Token = null;
                response.ResponseMsg = "Internal server error!";
                return response;
            }
        }

    }

  
}

