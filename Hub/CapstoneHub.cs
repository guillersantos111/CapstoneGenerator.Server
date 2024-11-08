using Microsoft.AspNetCore.SignalR;

namespace CapstoneGenerator.Server.Hubs
{
    public class CapstoneHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
