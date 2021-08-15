using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IServices
{
    public interface ITokenService : IService<User>
    {
        User Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
       AuthenticateResponse Login(AuthenticateRequest op, string ipAddress);

        User GetUserByName(string username);
    }
}
