using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Services
{
    public class UsersService : IUserService
    {


        private readonly IUsersRepositery _repository;

        public UsersService(IUsersRepositery repository)
        {
            _repository = repository;
        }


        public Users Add(Users obj)
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

        public List<Users> GetAll()
        {
            return _repository.GetAll();
        }

        public Users GetUsersById(int id)
        {
            return _repository.GetUsersById(id);
        }

        public Users Update(Users obj)
        {
            return _repository.Update(obj);
        }
    }
}
