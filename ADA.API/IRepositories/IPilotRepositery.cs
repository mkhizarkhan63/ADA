using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
    public interface IPilotRepositery
    {
       Pilot AddPilot( Pilot pilot);
        List<Pilot> GetAll();
      
    }
}
