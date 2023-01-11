using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

namespace AuthApi.Services
{
    public class SocketSessionService : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Send("Openned Connection at "+DateTime.Now);
        }
        protected override void OnClose(CloseEventArgs e)
        {
            Send("Openned Connection at " + DateTime.Now + "---" +e.ToString);
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            try
            {
                Cookie cookie = Context.CookieCollection.Cast<Cookie>().First(c => c.Name == "token");
                JwtSecurityToken jwt = new JwtSecurityTokenHandler().ReadJwtToken(cookie.Value);
                if(jwt.ValidTo >= DateTime.Now)
                {
                    Debug.WriteLine(cookie.Name);
                    Console.WriteLine("I, the server, received: " + e.Data);
                    Send("Server sats: you sent me this ? "+e.Data + "SENDER = ");
                }
            }catch 
            {
                Send("Closed Connection at " + DateTime.Now);
                Sessions.CloseSession(ID);
            }

        }
    }
}
