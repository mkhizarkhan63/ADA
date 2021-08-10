using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Services
{
    public class AirCraftService : IAirCraftService
    {
        private readonly IAirCraftRepository _airCraftRepository;

        public AirCraftService(IAirCraftRepository airCraftRepository)
        {
            _airCraftRepository = airCraftRepository;
        }
        
        public Aircraft Add(Aircraft obj)
        {
            return _airCraftRepository.Add(obj);
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            return _airCraftRepository.Delete(id , ModifiedBy , ModifiedOn);
        }

        public List<Aircraft> GetALL()
        {
            throw new NotImplementedException();
        }

        public int GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Aircraft Update(Aircraft obj)
        {
            throw new NotImplementedException();
        }
    }
}
