using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Services
{
    public class RoleService : IRoleService
    {


        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }


        public Role Add(Role obj)
        {
            return _repository.Add(obj);
        }

        public int Delete(int id, int ModifiedBy, DateTime ModifiedOn)
        {
            return _repository.Delete(id, ModifiedBy, ModifiedOn);
        }

        public int DeleteRecord(int id)
        {
            return _repository.DeleteRecord(id);
        }

        public List<Role> GetAll()
        {
            return _repository.GetAll();
        }

        public Role GetRoleById(int id)
        {
            return _repository.GetRoleById(id);
        }

        public Role Update(Role obj)
        {
            return _repository.Update(obj);
        }
    }
}
