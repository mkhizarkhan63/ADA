using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Services
{
    public class PilotService : IPilotService
    {

        private readonly IPilotRepositery _pilotRepository;

        public PilotService(IPilotRepositery pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }
        public Pilot Add(Pilot pilot)
        {
            return _pilotRepository.AddPilot(pilot);
        }

        public List<Pilot> GetAll()
        {
            return _pilotRepository.GetAll();
        }
    }
}
