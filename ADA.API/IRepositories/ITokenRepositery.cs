using ADAClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.IRepositories
{
    public interface ITokenRepositery
    {
        User RegistrationAccount(User user);
        List<User> GetUsers();

        int AddrefreshToken(RefreshToken token);
        RefreshToken getUserByRefreshToken(string token);

        RefreshToken refreshTokenvalidate(string token);

        User UserByRefreshTokenID(int id);
        int RemoveOldRefreshTokens(RefreshToken token);
        RefreshToken getRefreshTokenByID(int id);

        int UpdateRefreshToken(RefreshToken token);

        User GetbyName(string username);
    }
}
