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

        public List<Aircraft> GetAll()
        {
            return _airCraftRepository.GetALL();
        }

       

        public int GetById(int id)
        {
            return _airCraftRepository.GetById(id);
        }

        public Aircraft Update(Aircraft obj)
        {
            return _airCraftRepository.Update(obj);
        }
    }
}
