using ADA.API.DBManager;
using ADA.API.IRepositories;
using ADAClassLibrary;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Repositories
{
    public class TokenRepositery : ITokenRepositery
    {
        private readonly IDapper _dapper;
        public TokenRepositery(IDapper dapper)
        {
            _dapper = dapper;
        }
        public int AddrefreshToken(RefreshToken token)
        {
            var param = new DynamicParameters();
            param.Add("token", token.Token , DbType.String, ParameterDirection.Input);
            param.Add("isActive", token.IsActive, DbType.Boolean,  ParameterDirection.Input);
            param.Add("created", token.Created, DbType.DateTime,  ParameterDirection.Input);
            param.Add("createdbyIP", token.CreatedByIp, DbType.String,  ParameterDirection.Input);
            param.Add("isExpired", token.IsExpired, DbType.Boolean,  ParameterDirection.Input);
            param.Add("isRevoked", token.IsRevoked, DbType.Boolean,  ParameterDirection.Input);
            param.Add("ResonRevoked", token.ReasonRevoked, DbType.String,  ParameterDirection.Input);
            param.Add("ReplacedByToken", token.ReplacedByToken, DbType.String,  ParameterDirection.Input);
            param.Add("Revoked", token.Revoked, DbType.String,  ParameterDirection.Input);
            param.Add("RevokedByIP", token.RevokedByIp, DbType.String,  ParameterDirection.Input);
            param.Add("Expires", token.Expires, DbType.DateTime,  ParameterDirection.Input);
            param.Add("userID", token.userID, DbType.Int32,  ParameterDirection.Input);

            return _dapper.Insert<int>(@"[dbo].[usp_AddrefreshToken]", param);
        }

        public User RegistrationAccount(User user)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@firstname", user.FirstName, DbType.String, ParameterDirection.Input);
            param.Add("@lastname", user.LastName, DbType.String, ParameterDirection.Input);
            param.Add("@username", user.Username, DbType.String, ParameterDirection.Input);
            param.Add("@passwordhash", user.PasswordHash, DbType.String, ParameterDirection.Input);
            return _dapper.Insert<User>(@"[dbo].[usp_Adduser]", param);

        }

        public User GetbyName(string username)
        {
            var param = new DynamicParameters();
            param.Add("username", username, DbType.String, ParameterDirection.Input);
           return _dapper.Get<User>(@"[dbo].[usp_GetUserByName]", param);
        }

        public RefreshToken getRefreshTokenByID(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id , DbType.Int32 , ParameterDirection.Input);
           return  _dapper.Get<RefreshToken>(@"[dbo].[usp_usp_getRefreshTokenByID]", param);

        }

        public RefreshToken getUserByRefreshToken(string token)
        { 
            var param = new DynamicParameters();
            param.Add("token", token ,DbType.String , ParameterDirection.Input);

            return _dapper.Get<RefreshToken>(@"[dbo].[usp_getUserByRefreshToken]", param);

        }

        public List<User> GetUsers()
        {
            int? id = null;
            var param = new DynamicParameters();
            param.Add("id", id, DbType.Int32, ParameterDirection.Input);

            return _dapper.GetAll<User>(@"[dbo].[usp_getAllUsers]", param);
        }

        public RefreshToken refreshTokenvalidate(string token)
        {
       
            var param = new DynamicParameters();
            param.Add("token", token, DbType.String, ParameterDirection.Input);
            return _dapper.Get<RefreshToken>(@"s", param);
        }

        public int RemoveOldRefreshTokens(RefreshToken token)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("id", token.Id, DbType.Int32, ParameterDirection.Input);
            param.Add("isActive", token.IsActive, DbType.Boolean, ParameterDirection.Input);
            param.Add("Created", token.Created, DbType.DateTime, ParameterDirection.Input );
            return _dapper.Execute(@"[dbo].[usp_DeleteRefreshTokens]", param);
        }

        public int UpdateRefreshToken(RefreshToken token)
        {
            var param = new DynamicParameters();
            param.Add("id", token.Id, DbType.Int32, ParameterDirection.Input);
            param.Add("revoked", token.Revoked, DbType.DateTime, ParameterDirection.Input );
            param.Add("revokedbyip", token.RevokedByIp, DbType.String ,ParameterDirection.Input);
            param.Add("isrevoked", token.IsRevoked, DbType.Boolean, ParameterDirection.Input);
            param.Add("replacedbytoken", token.ReplacedByToken, DbType.String,  ParameterDirection.Input);
            param.Add("reasonrevoked", token.ReasonRevoked, DbType.String,  ParameterDirection.Input);
            param.Add("isactive", token.IsActive, DbType.Boolean,  ParameterDirection.Input);
            param.Add("isexpired", token.IsExpired, DbType.Boolean,  ParameterDirection.Input);

            return _dapper.Execute(@"[dbo].[usp_UpdateRefreshToken]", param);
        }

        public User UserByRefreshTokenID(int id)
        {
            var param = new DynamicParameters();
            param.Add("id", id, DbType.Int32, ParameterDirection.Input);

            return _dapper.Get<User>(@"[dbo].[usp_getUserByRefreshTokensID]", param);
        }
    }
}
