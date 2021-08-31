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

                obj.Password = Secure.EncryptData(obj.Password);
                var user = _authenticationService.Authenticate(obj);
                if (user == null) return CustomStatusResponse.GetResponse(320);
                else
                {
                    //if (user.PasswordExpireDays != 0)
                    //{
                    //    if (Convert.ToInt32((DateTime.Now.Date - user.LastPasswordUpdateDate.Date).TotalDays) >= user.PasswordExpireDays)
                    //    {
                    //        response.Status = 305;
                    //        response.Token = null;
                    //        response.Data = user.UserId;
                    //        return response;
                    //    }
                    //}

                    //if (user.DesignationId.Contains(1))
                    //{
                    //    //var dsignationCache = new CacheManager<Designation>(_memoryCache, _designationService).TryGetValue(designationCacheName).ToList();
                    //    var companyCache = new CacheManager<Company>(_memoryCache, _companyService).TryGetValue(companyCacheName).ToList().Select(x => x.Id).ToList();
                    //    var branchCache = new CacheManager<Branch>(_memoryCache, _branchService).TryGetValue(branchCacheName).ToList().Select(x => x.Id).ToList();
                    //    var factoryCache = new CacheManager<Factory>(_memoryCache, _factoryService).TryGetValue(factoryCacheName).ToList().Select(x => x.Id).ToList();
                    //    var teamCache = new CacheManager<Team>(_memoryCache, _teamService).TryGetValue(teamCacheName).ToList().Select(x => x.Id).ToList();
                    //    user.Companies = new List<int>();

                    //    for (int i = 0; i < companyCache.Count; i++)
                    //    {
                    //        user.Companies.Add(companyCache[i].Value);
                    //    }
                    //    user.Branches = new List<int>();
                    //    for (int i = 0; i < branchCache.Count; i++)
                    //    {
                    //        user.Branches.Add(branchCache[i].Value);
                    //    }
                    //    user.Factories = new List<int>();
                    //    for (int i = 0; i < factoryCache.Count; i++)
                    //    {
                    //        user.Factories.Add(factoryCache[i].Value);
                    //    }

                    //    user.Teams = new List<int>();
                    //    for (int i = 0; i < teamCache.Count; i++)
                    //    {
                    //        user.Teams.Add(teamCache[i].Value);
                    //    }


                    //    var permissionCache = new CacheManager<Permission>(_memoryCache, _permissionService).TryGetValue(permissionCacheName).ToList().Where(x => user.DesignationId.Contains(x.DesignationId)).ToList();
                    //    //var permissionActions = new CacheManager<BMCEnvicreteModulePagesAction>(_memoryCache, _bMCEnvicreteModulePagesActionService).TryGetValue(bMCEnvicreteModulePagesActionCacheName).ToList().Where(x => permissionCache.Any(c => c.PermissionId == x.Id)).ToList();

                    //    var permissionActions = new CacheManager<BMCEnvicreteModulePagesAction>(_memoryCache, _bMCEnvicreteModulePagesActionService).TryGetValue(bMCEnvicreteModulePagesActionCacheName).ToList();

                    //    var viewPermissions = permissionActions.Where(x => x.ActionName.ToLower().Contains("view")).ToList();

                    //    var bmcEnviModulePagesCache = new CacheManager<BMCEnvicreteModulePages>(_memoryCache, _bMCEnvicreteModulePagesService).TryGetValue(bMCEnvicreteModulePagesCacheName).ToList().Where(x => viewPermissions.Any(c => c.PageId == x.Id)).ToList();
                    //    //var viewModulePermissions = permissionCache.Where(x => x.CanView == true).ToList();
                    //    var bmcEnviModuleCache = new CacheManager<BMCEnvicreteModule>(_memoryCache, _bMCEnvicreteModuleService).TryGetValue(bMCEnvicreteModuleCacheName).ToList().Where(x => bmcEnviModulePagesCache.Any(c => c.ModuleId == x.Id)).ToList();
                    //    //var bmcEnviModulePagesCache = new CacheManager<BMCEnvicreteModulePages>(_memoryCache, _bMCEnvicreteModulePagesService).TryGetValue(bMCEnvicreteModulePagesCacheName).ToList();
                    //    List<DynamicModuleMenu> dynamicMenu = new List<DynamicModuleMenu>();
                    //    if (bmcEnviModuleCache.Count > 0)
                    //    {
                    //        if (bmcEnviModulePagesCache.Count > 0)
                    //        {
                    //            for (int i = 0; i < bmcEnviModuleCache.Count; i++)
                    //            {
                    //                var moduleName = bmcEnviModuleCache[i].Name;

                    //                DynamicModuleMenu dynamic = new DynamicModuleMenu();
                    //                dynamic.ModuleName = moduleName == null ? "No Module" : moduleName;
                    //                dynamic.OrderNo = bmcEnviModuleCache[i].OrderNo == null ? -1 : bmcEnviModuleCache[i].OrderNo;
                    //                dynamic.DynamicModulePagesMenus = new List<DynamicModulePagesMenu>();
                    //                var pages = bmcEnviModulePagesCache.Where(x => x.ModuleId == bmcEnviModuleCache[i].Id).ToList();
                    //                for (int j = 0; j < pages.Count; j++)
                    //                {
                    //                    DynamicModulePagesMenu dynamicModulePagesMenu = new DynamicModulePagesMenu();

                    //                    dynamicModulePagesMenu.PageName = pages[j].Name;
                    //                    dynamicModulePagesMenu.UrlController = pages[j].UrlController;
                    //                    dynamicModulePagesMenu.UrlAction = pages[j].UrlAction;
                    //                    dynamicModulePagesMenu.OrderNo = pages[j].OrderNo == null ? -1 : pages[j].OrderNo;
                    //                    dynamic.DynamicModulePagesMenus.Add(dynamicModulePagesMenu);
                    //                }
                    //                dynamicMenu.Add(dynamic);
                    //            }
                    //        }


                    //    }
                    //    if (dynamicMenu != null && dynamicMenu.Count > 0)
                    //    {
                    //        for (int i = 0; i < dynamicMenu.Count; i++)
                    //        {
                    //            dynamicMenu[i].DynamicModulePagesMenus = dynamicMenu[i].DynamicModulePagesMenus.OrderBy(c => c.OrderNo).ToList();
                    //        }
                    //    }

                    //    dynamicMenu = dynamicMenu.OrderBy(C => C.OrderNo).ToList();
                    //    user.DynamicMenu = JsonConvert.SerializeObject(dynamicMenu);
                    //    user.Permissions = JsonConvert.SerializeObject(new List<Permission>());
                    //}
                    //else
                    //{
                    //    var designationCache = new CacheManager<Designation>(_memoryCache, _designationService).TryGetValue(designationCacheName).ToList().Where(x => user.DesignationId.Any(c => c == x.Id.Value)).ToList();
                    //    var companyCache = new CacheManager<Company>(_memoryCache, _companyService).TryGetValue(companyCacheName).ToList().Select(x => x.Id).ToList();
                    //    var branchCache = new CacheManager<Branch>(_memoryCache, _branchService).TryGetValue(branchCacheName).ToList().Select(x => x.Id).ToList();
                    //    var factoryCache = new CacheManager<Factory>(_memoryCache, _factoryService).TryGetValue(factoryCacheName).ToList().Select(x => x.Id).ToList();
                    //    var teamCache = new CacheManager<Team>(_memoryCache, _teamService).TryGetValue(teamCacheName).ToList().Select(x => x.Id).ToList();
                    //    var employeeCache = new CacheManager<Employee>(_memoryCache, _employeeService).TryGetValue(employeeCacheName).ToList().FirstOrDefault(x => x.Id == user.UserId);

                    //    user.Companies = new List<int>();
                    //    user.Branches = new List<int>();
                    //    user.Factories = new List<int>();
                    //    //user.Companies = designationCache?.CompanyIds.Select(i => i).ToList();
                    //    //user.Branches = designationCache?.BranchIds.Select(i => (int?)i).ToList();
                    //    //user.Factories = designationCache?.FactoryIds.Select(i => (int?)i).ToList();

                    //    //for (int i = 0; i < designationCache.Count; i++)
                    //    //{
                    //    //    for (int j = 0; j < designationCache[i].CompanyIds.Count; j++)
                    //    //    {
                    //    //        user.Companies.Add(designationCache[i].CompanyIds[j]);
                    //    //    }
                    //    //    for (int k = 0; k < designationCache[i].BranchIds.Count; k++)
                    //    //    {
                    //    //        user.Branches.Add(designationCache[i].BranchIds[k]);
                    //    //    }
                    //    //    for (int l = 0; l < designationCache[i].FactoryIds.Count; l++)
                    //    //    {
                    //    //        user.Factories.Add(designationCache[i].FactoryIds[l]);
                    //    //    }

                    //    //}
                    //    user.Companies = new List<int>();

                    //    for (int i = 0; i < employeeCache?.CompanyIds?.Count; i++)
                    //    {
                    //        user.Companies.Add(employeeCache.CompanyIds[i]);
                    //    }
                    //    user.Branches = new List<int>();
                    //    for (int i = 0; i < employeeCache?.BranchIds?.Count; i++)
                    //    {
                    //        user.Branches.Add(employeeCache.BranchIds[i]);
                    //    }
                    //    user.Factories = new List<int>();
                    //    for (int i = 0; i < employeeCache?.FactoryIds?.Count; i++)
                    //    {
                    //        user.Factories.Add(employeeCache.FactoryIds[i]);
                    //    }

                    //    user.Teams = new List<int>();
                    //    for (int i = 0; i < employeeCache?.teamIds?.Count; i++)
                    //    {
                    //        user.Teams.Add(employeeCache.teamIds[i]);
                    //    }

                    //    var permissionCache = new CacheManager<Permission>(_memoryCache, _permissionService).TryGetValue(permissionCacheName).ToList().Where(x => user.DesignationId.Any(c => c == x.DesignationId)).ToList();

                    //    //.Where(x => x.DesignationId == user.DesignationId).ToList();
                    //    var permissionActionsCache = new CacheManager<BMCEnvicreteModulePagesAction>(_memoryCache, _bMCEnvicreteModulePagesActionService).TryGetValue(bMCEnvicreteModulePagesActionCacheName).ToList();

                    //    var permissionActions = permissionActionsCache.Where(x => permissionCache.Any(c => c.PermissionId == x.Id)).ToList();
                    //    var viewPermissions = permissionActions.Where(x => x.ActionName.ToLower().Contains("view")).ToList();

                    //    var bmcEnviModulePagesCache = new CacheManager<BMCEnvicreteModulePages>(_memoryCache, _bMCEnvicreteModulePagesService).TryGetValue(bMCEnvicreteModulePagesCacheName).ToList().Where(x => viewPermissions.Any(c => c.PageId == x.Id)).ToList();
                    //    //var viewModulePermissions = permissionCache.Where(x => x.CanView == true).ToList();
                    //    var bmcEnviModuleCache = new CacheManager<BMCEnvicreteModule>(_memoryCache, _bMCEnvicreteModuleService).TryGetValue(bMCEnvicreteModuleCacheName).ToList().Where(x => bmcEnviModulePagesCache.Any(c => c.ModuleId == x.Id)).ToList();






                    //    var viewModulePermissions = permissionActions.Where(x => permissionCache.Any(c => c.PermissionId == x.Id)).Select(c => c.ActionName).ToList();
                    //    //var bmcEnviModuleCache = new CacheManager<BMCEnvicreteModule>(_memoryCache, _bMCEnvicreteModuleService).TryGetValue(bMCEnvicreteModuleCacheName).ToList().Where(x => viewModulePermissions.Any(c => c.ModuleId == x.Id)).ToList();
                    //    //var bmcEnviModulePagesCache = new CacheManager<BMCEnvicreteModulePages>(_memoryCache, _bMCEnvicreteModulePagesService).TryGetValue(bMCEnvicreteModulePagesCacheName).ToList().Where(x => viewModulePermissions.Any(c => c.PageId == x.Id)).ToList();
                    //    List<DynamicModuleMenu> dynamicMenu = new List<DynamicModuleMenu>();
                    //    if (bmcEnviModuleCache.Count > 0)
                    //    {
                    //        if (bmcEnviModulePagesCache.Count > 0)
                    //        {
                    //            for (int i = 0; i < bmcEnviModuleCache.Count; i++)
                    //            {
                    //                var moduleName = bmcEnviModuleCache[i].Name;
                    //                DynamicModuleMenu dynamic = new DynamicModuleMenu();
                    //                dynamic.ModuleName = moduleName == null ? "No Module" : moduleName;
                    //                dynamic.OrderNo = bmcEnviModuleCache[i].OrderNo == null ? -1 : bmcEnviModuleCache[i].OrderNo;
                    //                dynamic.DynamicModulePagesMenus = new List<DynamicModulePagesMenu>();
                    //                var pages = bmcEnviModulePagesCache.Where(x => x.ModuleId == bmcEnviModuleCache[i].Id).ToList();
                    //                for (int j = 0; j < pages.Count; j++)
                    //                {
                    //                    DynamicModulePagesMenu dynamicModulePagesMenu = new DynamicModulePagesMenu();
                    //                    List<string> permissionActionKeys = permissionActionsCache.Where(x => x.PageId == pages[j].Id && !permissionCache.Exists(c => c.PermissionId == x.Id)).Select(i => i.ActionKey).ToList();


                    //                    dynamicModulePagesMenu.PageName = pages[j].Name;
                    //                    dynamicModulePagesMenu.UrlController = pages[j].UrlController;
                    //                    dynamicModulePagesMenu.UrlAction = pages[j].UrlAction;
                    //                    dynamicModulePagesMenu.OrderNo = pages[j].OrderNo == null ? -1 : pages[j].OrderNo;
                    //                    dynamicModulePagesMenu.ActionKeys = permissionActionKeys;

                    //                    dynamic.DynamicModulePagesMenus.Add(dynamicModulePagesMenu);
                    //                }
                    //                dynamicMenu.Add(dynamic);
                    //            }
                    //        }


                    //    }
                    //    if (dynamicMenu != null && dynamicMenu.Count > 0)
                    //    {
                    //        for (int i = 0; i < dynamicMenu.Count; i++)
                    //        {
                    //            dynamicMenu[i].DynamicModulePagesMenus = dynamicMenu[i].DynamicModulePagesMenus.OrderBy(c => c.OrderNo).ToList();
                    //        }
                    //    }
                    //    dynamicMenu = dynamicMenu.OrderBy(C => C.OrderNo).ToList();
                    //    user.DynamicMenu = JsonConvert.SerializeObject(dynamicMenu);
                    //    user.Permissions = JsonConvert.SerializeObject(viewModulePermissions);
                    //    //user.PermissionActionKeys = JsonConvert.SerializeObject(viewModulePermissions);
                    //    //user.DynamicMenu = JsonConvert.SerializeObject(new List<DynamicModuleMenu>());
                    //    //user.Permissions = JsonConvert.SerializeObject(new List<Permission>());
                    //}

                    //var menu = JsonConvert.DeserializeObject<List<DynamicModuleMenu>>(user.DynamicMenu);


                    //if (menu == null | menu.Count == 0)
                    //{
                    //    response = CustomStatusResponse.GetResponse(304);
                    //    response.ResponseMsg = "You do not have permission to view any page.";
                    //    response.Token = null;
                    //    return response;
                    //}


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

    public class DynamicModuleMenu
    {
        public string ModuleName { get; set; }
        public int? OrderNo { get; set; }
        public List<DynamicModulePagesMenu> DynamicModulePagesMenus { get; set; }
    }
    public class DynamicModulePagesMenu
    {
        public string PageName { get; set; }
        public string UrlController { get; set; }
        public string UrlAction { get; set; }
        public int? OrderNo { get; set; }
        public List<string> ActionKeys { get; set; }
    }
}

