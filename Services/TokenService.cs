using ReegornApi.Data;
using ReegornApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using System;

namespace ReegornApi.Services
{
    public class TokenService
    {
        public static TokenModel GenerateToken(UserModel user,List<RolesModel> roles, string IpAddress)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Global.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            foreach (var r in roles)
            {
                tokenDescriptor.Subject.AddClaim(
                new Claim(ClaimTypes.Role, r.Role.ToString())
                );
            }
            var token = tokenHandler.CreateToken(tokenDescriptor);
            TokenModel tokenModel = new TokenModel();
            tokenModel.Token = tokenHandler.WriteToken(token);
            tokenModel.Expires = tokenDescriptor.Expires;
            tokenModel.TokenType = "Bearer";
            tokenModel.IsNewIpAddress = user.IsNewIpAddress;
            tokenModel.IpAddress = IpAddress;
            return tokenModel;
        }
    }
}
