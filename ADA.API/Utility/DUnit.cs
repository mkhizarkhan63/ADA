using ADA.API.IRepositories;
using ADA.API.IServices;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Utility
{
    public class DUnit : IDIUnit
    {
        public DUnit( IAirCraftService AirCraftService , IMemoryCache MemoryCache , IPilotService PilotService , IStaffService StaffService , IFlightService FlightService)
        {
            airCraftService = AirCraftService;
            memoryCache = MemoryCache;
            pilotService = PilotService;
            staffService = StaffService;
            flightService = FlightService;
        }
        public IAirCraftService airCraftService { get; }

        public IMemoryCache memoryCache { get; }


        public IPilotService pilotService { get; }
        public IStaffService staffService { get; }
        public IFlightService flightService { get; }


    }
}
