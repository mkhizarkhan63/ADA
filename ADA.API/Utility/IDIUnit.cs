
using ADA.API.IRepositories;
using ADA.API.IServices;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Utility
{
    public interface IDIUnit
    {

        IAirCraftService airCraftService { get; }

        IMemoryCache memoryCache { get; }

        IPilotService pilotService { get; }
        IStaffService staffService { get; }
        IFlightService flightService { get; }
    }
}
