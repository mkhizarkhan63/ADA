using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Dapper;
using ADA.API.DBManager;
using ADAClassLibrary.DTOLibraries;
using System.Data;

namespace ADA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IDapper _dapper;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Username", "VON" ,DbType.String, ParameterDirection.Input);
            parameters.Add("Password", "12345", DbType.String, ParameterDirection.Input);

            var data = _dapper.Get<ClaimDTO>(@"[dbo].[usp_ValidateLogin]", parameters);


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    //public class ClaimDTO
    //{

    //    public int UserId { get; set; }
    //    public string Username { get; set; }
    //    public bool SuperAdminRights { get; set; }
    //    public bool StaffActive { get; set; }
    //    public bool StaffRights { get; set; }

    //}
}
