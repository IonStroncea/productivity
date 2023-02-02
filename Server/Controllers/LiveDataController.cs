using ComputerInfo;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary;
using System.Diagnostics.SymbolStore;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveDataController : ControllerBase
    {
        private IDataSender dataSender;

        public LiveDataController(IDataSender dataSender)
        {
            this.dataSender = dataSender;
        }

        [HttpGet]
        public async Task GetAllByType()
        {
            var context = ControllerContext.HttpContext;
            if (context.WebSockets.IsWebSocketRequest)
            {
                using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
                {
                    await GetLiveData(context, webSocket);
                }
            }
            else 
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        private async Task GetLiveData(HttpContext context, WebSocket socket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            string message = System.Text.Encoding.Default.GetString(buffer);

            string [] values = message.Split('+');

            int computerId = Int32.Parse(values[1]);
            int userId = Int32.Parse(values[2]);
            RSInfoType type = (RSInfoType)Enum.Parse(typeof(RSInfoType), values[0]);

            while (socket.State == WebSocketState.Open)
            {
                if (dataSender.CacheContaints(computerId))
                {
                    MRSInfo Minfo = dataSender.GetLatestMRSInfo(computerId);

                    RSInfo info = Minfo.GetInfo(type);

                    string jsonResult = "{\"date\": \"" + info.Date.ToString("dd-MM-yyyyThh:mm:ss") + "\", \"usage\": \"" + info.Usage + "\" }";
                    var bytes = Encoding.ASCII.GetBytes(jsonResult);
                    var arraySegment = new ArraySegment<byte>(bytes);

                    await socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else 
                {
                    string jsonResult = "{\"date\": \"" + 0 + "\", \"usage\": \"" + 0 + "\" }";
                    var bytes = Encoding.ASCII.GetBytes(jsonResult);
                    var arraySegment = new ArraySegment<byte>(bytes);

                    await socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                }

                result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                message = System.Text.Encoding.Default.GetString(buffer);

                values = message.Split('+');

                computerId = Int32.Parse(values[1]);
                userId = Int32.Parse(values[2]);
                type = (RSInfoType)Enum.Parse(typeof(RSInfoType), values[0]);

                Thread.Sleep(1000);
            }
        }
    }
}
