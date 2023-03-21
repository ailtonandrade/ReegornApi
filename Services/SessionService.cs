using Newtonsoft.Json;
using ReegornApi;
using ReegornApi.Repositories;
using ReegornApi.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;
using System;

namespace AuthApi.Services
{
    public class SessionService
    {
        public async Task<List<UserModel>> GetByAccount(string? acc)
        {
            UserRepo repo = new UserRepo();
            var db = Transactions.Create();

            try
            {
                List<UserModel> response = await repo.GetByAccount(acc, db);
                return response;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
