using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
    public interface IPilotService : IService<Pilot>
    {
        Pilot Add(Pilot pilot);
    }
}
