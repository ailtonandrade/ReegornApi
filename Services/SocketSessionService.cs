using AuthApi.Models;
using AuthApi.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using ReegornApi;
using ReegornApi.Repositories;
using ReegornApi.Services;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

namespace AuthApi.Services
{
    public class SocketSessionService : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            SessionRepo repo = new SessionRepo();
            var db = Transactions.Create();

            try
            {
                validadeAccess();
                try
                {
                    CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(e.Data);
                    repo.UpdateCharacterLocal(character, db,1);
                    
                    Send(JsonConvert.SerializeObject(BuildSessionData(character, db)));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch 
            {
                dynamic data = JObject.Parse(e.Data);
                repo.UpdateCharacterLocal(data, db, 0);
                Send("Closed Connection at - " + DateTime.Now);
                db.Close();
                Sessions.CloseSession(ID);
            }

        }

        private void validadeAccess()
        {
            try
            {
                Cookie cookie = Context.CookieCollection.Cast<Cookie>().First(c => c.Name == "token");
                JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(cookie.Value);
                if (jwt.ValidTo >= DateTime.Now)
                {
                    Debug.WriteLine(cookie.Name);
                }
                else
                {
                    throw new Exception("Erro ao validar as credenciais.");
                }
            }
            catch
            {
                Send("Closed Connection at " + DateTime.Now);
                Sessions.CloseSession(ID);
            }
        }
        private SessionModel BuildSessionData(CharacterModel character, OracleConnection db)
        {
            SessionModel session = new SessionModel();
            GetDataSession(character, session, db);
            session.infos = DataListInfos(character, db);
            session.environments = DataListEnvironments(character, db);
            session.creatures = DataListCreatures(character, db);
            session.players = DataListPlayers(character, db);

            return session;
        }

        private void GetDataSession(CharacterModel data,SessionModel session, OracleConnection db)
        {
            //TODO fazeer os dados virem do repo.
            session.world = data.world;
            session.local = data.local;
        }
        private List<ObjectDataModel> DataListEnvironments(CharacterModel data, OracleConnection db)
        {

            return EnvironmentObjects.data;
        }
        private List<InfoSessionModel> DataListInfos(CharacterModel data, OracleConnection db)
        {

            return null;
        }
        private List<CreatureModel> DataListCreatures(CharacterModel data, OracleConnection db)
        {
            SessionRepo repo = new SessionRepo();

            return null;
        }
        private List<CharacterModel> DataListPlayers(CharacterModel data, OracleConnection db)
        {
            SessionRepo repo = new SessionRepo();

            return repo.GetAllPlayers(data, db).Result;
        }
        protected override void OnOpen()
        {
            Send("Openned Connection at " + DateTime.Now);
        }
        protected override void OnClose(CloseEventArgs e)
        {
            Send("Openned Connection at " + DateTime.Now + "---" + e.ToString);
        }

    }
}
