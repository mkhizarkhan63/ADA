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
        public DUnit( IAirCraftService AirCraftRepository , IMemoryCache MemoryCache)
        {
            airCraftService = AirCraftRepository;
            memoryCache = MemoryCache;
        }
        public IAirCraftService airCraftService { get; }

        public IMemoryCache memoryCache { get; }
    }
}
