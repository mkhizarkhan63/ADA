
using ADAClassLibrary.DTOLibraries;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ADA.API.Utility
{
    public class TokenManager
    {
        public static Dictionary<string, string> GeneratedTokens = new Dictionary<string, string>();
        //static string keyText = "Reuters2020-AASA-BMC";
        //static string encryptionSecureKey = "-AASA-BMCReuters2020";
        private static string Secret = "J8c20cxkPZCC/0e0ZUcjrGocsk95gOAqjzJ09apAklM=";
        private static double TokenExpireTime = 3600.0;
        public static string GenerateToken(ClaimDTO obj)
        {

            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Username", Convert.ToString(obj.Username)),
                    //new Claim("UserId",Convert.ToString(obj.UserId)),
                    new Claim("Email", Convert.ToString(obj.Email)),
                    new Claim("LoginId", Convert.ToString(obj.LoginId)),
                    //new Claim("FirstName", Convert.ToString(obj.FirstName)),
                    //new Claim("LastName", Convert.ToString(obj.LastName)),
                    new Claim("RoleId", Convert.ToString(obj.RoleId)),
                    new Claim("RoleName", Convert.ToString(obj.RoleName)),
                    //new Claim("DesignationId",string.Join(',',obj.DesignationId)),
                   // new Claim("DynamicMenu", obj.DynamicMenu),
                    //new Claim("Permissions", obj.Permissions),
           
                   // new Claim("MaxDiscountApproval", Convert.ToString(obj.MaxDiscountApproval)),
          
                    //new Claim("Companies", string.Join(',',obj.Companies)),
                    //new Claim("Branches", string.Join(',',obj.Branches)),
                    //new Claim("Factories", string.Join(',',obj.Factories)),
                    //new Claim("Teams", string.Join(',',obj.Teams)),
                }
                ),
                Issuer = "Envicrete",
                /*IssuedAt = DateTime.UtcNow.AddHours(Convert.ToDouble(ConfigurationManager.AppSettings["UTCTime"])),*/
                Expires = DateTime.Now.AddMinutes(TokenExpireTime),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

            string value = string.Empty;
            bool keyExists = GeneratedTokens.TryGetValue(obj.Username, out value);

            if (keyExists)
            {
                GeneratedTokens.Remove(obj.Username);
                GeneratedTokens.Add(obj.Username, handler.WriteToken(token).ToString());
            }
            else
            {
                GeneratedTokens.Add(obj.Username, handler.WriteToken(token).ToString());
            }

            return handler.WriteToken(token);
        }
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static ClaimDTO ValidateToken(string token)
        {
            ClaimDTO obj = new ClaimDTO();
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim userName = identity.FindFirst("Username");
           // Claim userId = identity.FindFirst("UserId");
            Claim email = identity.FindFirst("Email");
            Claim loginId = identity.FindFirst("LoginId");
            //Claim firstName = identity.FindFirst("FirstName");
            //Claim lastName = identity.FindFirst("LastName");
            Claim roleId = identity.FindFirst("RoleId");
            Claim rolename = identity.FindFirst("RoleName");
            //Claim designationId = identity.FindFirst("DesignationId");
           // Claim dynamicMenu = identity.FindFirst("DynamicMenu");
           // Claim permissions = identity.FindFirst("Permissions");
           // Claim maxDiscountApproval = identity.FindFirst("MaxDiscountApproval");

            //Claim companies = identity.FindFirst("Companies");
            //Claim branches = identity.FindFirst("Branches");
            //Claim factories = identity.FindFirst("Factories");
            //Claim teams = identity.FindFirst("Teams");

            obj.Username = userName.Value;
            //obj.UserId = Convert.ToInt32(userId.Value);
            obj.Email = email.Value;
            obj.LoginId = Convert.ToInt32(loginId.Value);
           // obj.FirstName = firstName.Value;
           // obj.LastName = lastName.Value;
            obj.RoleId = Convert.ToInt32(roleId.Value);
            obj.RoleName = rolename.Value;
            //obj.MaxDiscountApproval= Convert.ToInt32(maxDiscountApproval.Value);
            //if (designationId.Value != null && designationId.Value != "")
            //{
            //    obj.DesignationId = designationId.Value.Split(',').Select(x => int.Parse(x)).ToList();
            //}
            //else
            //{
            //    obj.DesignationId = new List<int>();
            //}
           // obj.DynamicMenu = dynamicMenu.Value;
            //obj.Permissions = permissions.Value;
            //obj.MaxApprovalAmount = Convert.ToDecimal(maxApprovalAmount.Value);
            //obj.MinApprovalAmount = Convert.ToDecimal(minApprovalAmount.Value);
            //obj.GeoLocation = Convert.ToInt32(geoLocation.Value);

            //List<decimal> maxApproveAmount = new List<decimal>();
            //if (maxApprovalAmount.Value != null && maxApprovalAmount.Value != "")
            //{
            //    maxApproveAmount = maxApprovalAmount.Value.Split(',').Select(x => decimal.Parse(x.Trim())).ToList();
            //    obj.MaxApprovalAmount = maxApproveAmount;
            //}


            //user = userClaim.Value;
            return obj;
        }

        public static ClaimDTO GetValidateToken(HttpRequest httpRequest)
        {
            string value = string.Empty;
            if (!httpRequest.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = httpRequest.Headers["Authorization"];
            ClaimDTO claimDTO = null;
            string token = authHeader;
            //if (authHeader !=n)
            //{
            //    token = Request.Headers.Authorization.Scheme.ToString() + " " + Request.Headers.Authorization.Parameter.ToString();
            //}
            //else
            //{
            //    return null;
            //}
            //if (authHeader != null)
            //{
            //    token = authHeader.ToString().Split(" ")[1];
            //}

            //var token = Request.Headers.Authorization.Parameter.ToString(); //GetValues("Authorization").FirstOrDefault();
            //if (token == null)
            //{
            //    token = Request.Headers.GetValues("Authorization").FirstOrDefault();
            //    if(token==null)
            //        return null;
            //}



            // string[] headerValues = token.Split(' ');
            //string generatedToken = null;
            if (token != null)
            {
                var item = GeneratedTokens.FirstOrDefault(kvp => kvp.Value == token);
                //if (GeneratedTokens.TryGetValue(headerValues[2], out generatedToken))
                //{
                //    generatedToken=GeneratedTokens[headerValues[2]];
                //}
                if (!item.Equals(default(KeyValuePair<string, string>)))
                {
                    GeneratedTokens.Remove(item.Key);
                }
                
            }

            claimDTO = TokenManager.ValidateToken(token);
            if (claimDTO == null)
            {
                return null;
            }

            return claimDTO;
        }

        public static string RemoveToken(string token)
        {
            var item = GeneratedTokens.FirstOrDefault(kvp => kvp.Value == token);
            if (!item.Equals(default(KeyValuePair<string, string>)))
            {
                GeneratedTokens.Remove(item.Key);
                return null;
            }
            else
            {
                return null;
            }

        }

    }
}
