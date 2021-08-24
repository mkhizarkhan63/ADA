using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.web.Areas.DashBoard.Controllers
{
    [Area("DashBoard")]
    [Route("DashBoard/[controller]/[action]")]
    public class FlightController : Controller
    {
        public IActionResult Flight() { 
            return View();
        }
    }
}
