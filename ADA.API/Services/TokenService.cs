using ADA.API.Authorization;
using ADA.API.Helpers;
using ADA.API.IRepositories;
using ADA.API.IServices;
using ADAClassLibrary;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ADA.API.Services
{
    public class TokenService : ITokenService
    {
        private ITokenRepositery _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public TokenService(
            ITokenRepositery context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }
        public User Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var password = BCryptNet.HashPassword(model.Password);
            User user = new User()
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                Username = model.Username,
                PasswordHash = password
            };
            // validate
            if (user == null || !BCryptNet.Verify(model.Password, password))
                throw new AppException("Username or password is incorrect");

            //authentication successful so generate jwt and refresh tokens
            return _context.RegistrationAccount(user);
           // var jwtToken = _jwtUtils.GenerateJwtToken(userfortoken);
           // var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);

           // RefreshToken refreshTokenobject = new RefreshToken()
           // {
           //     Token = refreshToken.Token,

           //     Expires = refreshToken.Expires,
           //     Created = refreshToken.Created,
           //     CreatedByIp = refreshToken.CreatedByIp,
           //     userID = userfortoken.Id

           // };

           // var tokenID = _context.AddrefreshToken(refreshTokenobject);

           // //remove old refresh tokens from user
           //removeOldRefreshTokens(tokenID);
        }

        public AuthenticateResponse Login(AuthenticateRequest op, string ipAddress)
        {

            var user = _context.GetbyName(op.Username);
            var password = BCryptNet.HashPassword(op.Password);
            // validate
            if (user == null || !BCryptNet.Verify(op.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");



            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            int userid = user.Id;
            user.Id = userid;
            RefreshToken refreshTokenobject = new RefreshToken()
            {
                Token = refreshToken.Token,

                Expires = refreshToken.Expires,
                Created = refreshToken.Created,
                CreatedByIp = refreshToken.CreatedByIp,
                userID = userid

            };

            var tokenID = _context.AddrefreshToken(refreshTokenobject);

            // remove old refresh tokens from user
            removeOldRefreshTokens(tokenID);


            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);


        }


        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            RefreshToken Token = getUserByRefreshToken(token);
            if (Token.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(Token, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");

            }
            if (!Token.IsActive)
                throw new AppException("Invalid token");

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = rotateRefreshToken(Token, ipAddress);

            _context.AddrefreshToken(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(Token.Id);

            User user = _context.UserByRefreshTokenID(Token.Id);

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var userToken = getUserByRefreshToken(token);
            //var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (!userToken.IsActive)
                throw new AppException("Invalid token");

            // revoke token and save
            revokeRefreshToken(userToken, ipAddress, "Revoked without replacement");
            _context.UpdateRefreshToken(userToken);

        }
        public User GetUserByName(string username)
        {
            return _context.GetbyName(username);

        }

        private RefreshToken getUserByRefreshToken(string token)
        {

            RefreshToken userbytoken = _context.getUserByRefreshToken(token);

            if (userbytoken == null)
                throw new AppException("Invalid token");

            return userbytoken;
        }
        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }
        private void removeOldRefreshTokens(int id)
        {

            var grr = _context.getRefreshTokenByID(id);
            _context.RemoveOldRefreshTokens(grr);
            // remove old inactive refresh tokens from user based on TTL in app settings

        }
        private void revokeDescendantRefreshTokens(RefreshToken user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked

            if (!string.IsNullOrEmpty(user.ReplacedByToken))
            {
                var childToken = _context.getUserByRefreshToken(user.Token);

                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, ipAddress, reason);

            }
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

        public List<User> GetAll()
        {
            return _context.GetUsers();
        }
    }
}
