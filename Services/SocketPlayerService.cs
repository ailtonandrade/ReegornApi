using WebSocketSharp;
using WebSocketSharp.Server;

namespace AuthApi.Services
{
    public class SocketPlayerService : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Context.ToString();
            Send("Openned Connection at "+DateTime.Now);
        }
        protected override void OnClose(CloseEventArgs e)
        {
            Send("Openned Connection at " + DateTime.Now + "---" +e.ToString);
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("I, the server, received: " + e.Data);
            Send("Server sats: you sent me this ? "+e.Data);
        }
    }
}
