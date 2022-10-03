using ReegornApi.Data;
using ReegornApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReegornApi.Services
{
    public class TokenService
    {
        public static TokenModel GenerateToken(UserModel user,List<RolesModel> roles)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Global.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),

                }),
                Expires = DateTime.UtcNow.AddSeconds(30),
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
            return tokenModel;
        }
    }
}
